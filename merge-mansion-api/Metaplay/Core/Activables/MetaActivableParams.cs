using System.Collections.Generic;
using Metaplay.Core.Model;
using Metaplay.Core.Player;
using Metaplay.Core.Schedule;
using System;

namespace Metaplay.Core.Activables
{
    [MetaSerializable]
    public class MetaActivableParams
    {
        [MetaMember(1)]
        public bool IsEnabled; // 0x10
        [MetaMember(2)]
        public List<MetaRef<PlayerSegmentInfoBase>> Segments; // 0x18
        [MetaMember(3)]
        public List<PlayerCondition> AdditionalConditions; // 0x20
        [MetaMember(4)]
        public MetaActivableLifetimeSpec Lifetime; // 0x28
        [MetaMember(5)]
        public bool IsTransient; // 0x30
        [MetaMember(6)]
        public MetaScheduleBase Schedule; // 0x38
        [MetaMember(7)]
        public int? MaxActivations; // 0x40
        [MetaMember(8)]
        public int? MaxTotalConsumes; // 0x48
        [MetaMember(9)]
        public int? MaxConsumesPerActivation; // 0x50
        [MetaMember(10)]
        public MetaActivableCooldownSpec Cooldown; // 0x58
        [MetaMember(11)]
        public bool AllowActivationAdjustment; // 0x60
        public MetaActivableParams()
        {
        }

        public MetaActivableParams(bool isEnabled, List<MetaRef<PlayerSegmentInfoBase>> segments, List<PlayerCondition> additionalConditions, MetaActivableLifetimeSpec lifetime, bool isTransient, MetaScheduleBase schedule, int? maxActivations, int? maxTotalConsumes, int? maxConsumesPerActivation, MetaActivableCooldownSpec cooldown, bool allowActivationAdjustment)
        {
        }
    }
}