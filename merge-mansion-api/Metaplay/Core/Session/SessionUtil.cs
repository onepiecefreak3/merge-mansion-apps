using System;
using System.Linq;
using Metaplay.Metaplay.Core.Message;
using Metaplay.Metaplay.Core.Serialization;

namespace Metaplay.Metaplay.Core.Session
{
    public static class SessionUtil
    {
        private static readonly bool EnableMessagingChecksums; // 0x0

        public static void HandleSendPayloadMessage(SessionParticipantState state, MetaMessage message)
        {
            state.RememberedSent.Enqueue(message);
            state.NumSent++;
        }

        public static ResumeResult HandleResume(SessionParticipantState our, SessionResumptionInfo their)
        {
            if (our == null)
                return new ResumeResult.Failure.WeHaveNoSession();

            if (their.Token != our.Token)
                return new ResumeResult.Failure.TokenMismatch(our.Token, their.Token);

            var ackRes = ValidateAck(our, their.Acknowledgement);
            if (ackRes == null)
                throw new InvalidOperationException("Unknown ValidateAckResult: null");

            if (ackRes is ValidateAckResult.Failure acf)
                return new ResumeResult.Failure.ValidateAckFailure(acf);

            if (ackRes is ValidateAckResult.Success acs)
            {
                if (their.Acknowledgement.NumReceived < our.NumSent - our.RememberedSent.Count)
                    return new ResumeResult.Failure.WeHaveForgottenTooMany(our.NumSent, our.RememberedSent.Count, their.Acknowledgement.NumReceived);

                ApplyAck(our, acs);
                return new ResumeResult.Success(acs);
            }

            throw new InvalidOperationException($"Unknown ValidateAckResult: {ackRes.GetType().Name}");
        }

        public static ReceiveResult HandleReceive(SessionParticipantState state, MetaMessage message)
        {
            if (!(message is SessionControlMessage))
                return new ReceiveResult.ReceivePayloadMessage(HandleReceivePayloadMessage(state, message));

            if (!(message is SessionAcknowledgementMessage sam))
                throw new ArgumentException($"Unknown SessionControlMessage: {message}");

            var ackRes = ValidateAck(state, sam.Acknowledgement);
            if (ackRes is ValidateAckResult.Success acs)
                ApplyAck(state, acs);

            return new ReceiveResult.HandleAck(ackRes);
        }

        private static ReceivePayloadMessageResult HandleReceivePayloadMessage(SessionParticipantState state, MetaMessage payloadMessage)
        {
            if (EnableMessagingChecksums)
                state.ChecksumForReceived = ComputeUpdatedMessagingChecksum(state.ChecksumForReceived, payloadMessage);

            var numReceived = state.NumReceived;
            var newNumReceived = numReceived+1;
            state.NumReceived = newNumReceived;

            var shouldSendAck = state.AcknowledgedNumReceived + 5 <= newNumReceived;
            if (shouldSendAck)
                state.AcknowledgedNumReceived = newNumReceived;

            return new ReceivePayloadMessageResult(numReceived, shouldSendAck);
        }

        private static ValidateAckResult ValidateAck(SessionParticipantState our, SessionAcknowledgement their)
        {
            if (our.NumSent < their.NumReceived)
                return new ValidateAckResult.Failure.TheirNumReceivedTooHigh(their.NumReceived, our.NumSent);

            if (their.NumReceived < our.NumAcknowledgedSent)
                return new ValidateAckResult.Failure.TheirNumReceivedTooLow(their.NumReceived, our.NumAcknowledgedSent);

            var ourNumSent = our.NumSent - our.RememberedSent.Count;
            var ourNumMax = System.Math.Max(0, their.NumReceived - ourNumSent);

            if (!EnableMessagingChecksums || ourNumSent > their.NumReceived)
                return new ValidateAckResult.Success(ourNumMax, their.NumReceived);

            var messages = our.RememberedSent.Take(ourNumMax);
            var eh = our.ChecksumForForgottenSent;
            foreach (var msg in messages)
                eh = ComputeUpdatedMessagingChecksum(eh, msg);

            if (eh != their.ChecksumForReceived)
                return new ValidateAckResult.Failure.ChecksumMismatch(eh, their.ChecksumForReceived);

            return new ValidateAckResult.Success(ourNumMax, their.NumReceived);
        }

        private static void ApplyAck(SessionParticipantState our, ValidateAckResult.Success success)
        {
            if (success.OurNumToNewlyForget > 0)
            {
                for (var i = 0; i < success.OurNumToNewlyForget; i++)
                    ForgetSentMessage(our);
            }

            if (our != null)
                our.NumAcknowledgedSent = success.TheirNumReceived;
        }

        private static uint ComputeUpdatedMessagingChecksum(uint oldChecksum, MetaMessage message)
        {
            var serialized = MetaSerialization.SerializeTagged(message, MetaSerializationFlags.SendOverNetwork, null, null);
            return MurmurHash.MurmurHash2(serialized, oldChecksum);
        }

        private static void ForgetSentMessage(SessionParticipantState state)
        {
            var msg = state.RememberedSent.Dequeue();
            if (!EnableMessagingChecksums)
                state.ChecksumForForgottenSent = ComputeUpdatedMessagingChecksum(state.ChecksumForForgottenSent, msg);
        }

        public abstract class ReceiveResult
        {
            public class HandleAck : ReceiveResult
            {
                public ValidateAckResult Value { get; } // 0x10

                public HandleAck(ValidateAckResult value)
                {
                    Value = value;
                }
            }

            public class ReceivePayloadMessage : ReceiveResult
            {
                public ReceivePayloadMessageResult Value { get; } // 0x10

                public ReceivePayloadMessage(ReceivePayloadMessageResult value)
                {
                    Value = value;
                }
            }
        }

        public abstract class ResumeResult
        {
            public class Success : ResumeResult
            {
                public ValidateAckResult.Success ValidateAckSuccess { get; } // 0x10

                public Success(ValidateAckResult.Success validateAckSuccess)
                {
                    ValidateAckSuccess = validateAckSuccess;
                }
            }

            public abstract class Failure : ResumeResult
            {
                public class WeHaveNoSession : Failure
                {
                }

                public class TokenMismatch : Failure
                {
                    public SessionToken OurToken { get; } // 0x10
                    public SessionToken TheirToken { get; } // 0x18

                    public TokenMismatch(SessionToken ourToken, SessionToken theirToken)
                    {
                        OurToken = ourToken;
                        TheirToken = theirToken;
                    }
                }

                public class ValidateAckFailure : Failure
                {
                    public ValidateAckResult.Failure Value { get; } // 0x10

                    public ValidateAckFailure(ValidateAckResult.Failure value)
                    {
                        Value = value;
                    }
                }

                public class WeHaveForgottenTooMany : Failure
                {
                    public int OurNumSent { get; } // 0x10
                    public int OurNumRememberedSent { get; } // 0x14
                    public int TheirNumReceived { get; } // 0x14

                    public WeHaveForgottenTooMany(int ourNumSent, int ourNumRememberedSent, int theirNumReceived)
                    {
                        OurNumSent = ourNumSent;
                        OurNumRememberedSent = ourNumRememberedSent;
                        TheirNumReceived = theirNumReceived;
                    }
                }
            }
        }

        public abstract class ValidateAckResult
        {
            public class Success : ValidateAckResult
            {
                public int OurNumToNewlyForget { get; } // 0x10
                public int TheirNumReceived { get; } // 0x14

                public Success(int ourNumToNewlyForget, int theirNumReceived)
                {
                    OurNumToNewlyForget = ourNumToNewlyForget;
                    TheirNumReceived = theirNumReceived;
                }
            }

            public abstract class Failure : ValidateAckResult
            {
                protected Failure() { }

                public class TheirNumReceivedTooHigh : Failure
                {
                    public int TheirNumReceived { get; } // 0x10
                    public int OurNumSent { get; } // 0x14

                    public TheirNumReceivedTooHigh(int theirNumReceived, int ourNumSent)
                    {
                        TheirNumReceived = theirNumReceived;
                        OurNumSent = ourNumSent;
                    }
                }

                public class TheirNumReceivedTooLow : Failure
                {
                    public int TheirNumReceived { get; } // 0x10
                    public int OldNumAcknowledgedByThem { get; } // 0x14

                    public TheirNumReceivedTooLow(int theirNumReceived, int oldNumAcknowledgedByThem)
                    {
                        TheirNumReceived = theirNumReceived;
                        OldNumAcknowledgedByThem = oldNumAcknowledgedByThem;
                    }
                }

                public class ChecksumMismatch : Failure
                {
                    public uint OurChecksum { get; } // 0x10
                    public uint TheirChecksum { get; } // 0x14

                    public ChecksumMismatch(uint ourChecksum, uint theirChecksum)
                    {
                        OurChecksum = ourChecksum;
                        TheirChecksum = theirChecksum;
                    }
                }
            }
        }

        public class ReceivePayloadMessageResult
        {
            public int PayloadMessageIndex { get; } // 0x10
            public bool ShouldSendAcknowledgement { get; } // 0x14

            public ReceivePayloadMessageResult(int payloadMessageIndex, bool shouldSendAcknowledgement)
            {
                PayloadMessageIndex = payloadMessageIndex;
                ShouldSendAcknowledgement = shouldSendAcknowledgement;
            }
        }
    }
}
