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
        [MetaMember(1, (MetaMemberFlags)0)]
        public bool IsEnabled; // 0x10
        [MetaMember(2, (MetaMemberFlags)0)]
        public List<MetaRef<PlayerSegmentInfoBase>> Segments; // 0x18
        [MetaMember(3, (MetaMemberFlags)0)]
        public List<PlayerCondition> AdditionalConditions; // 0x20
        [MetaMember(4, (MetaMemberFlags)0)]
        public MetaActivableLifetimeSpec Lifetime; // 0x28
        [MetaMember(5, (MetaMemberFlags)0)]
        public bool IsTransient; // 0x30
        [MetaMember(6, (MetaMemberFlags)0)]
        public MetaScheduleBase Schedule; // 0x38
        [MetaMember(7, (MetaMemberFlags)0)]
        public int? MaxActivations; // 0x40
        [MetaMember(8, (MetaMemberFlags)0)]
        public int? MaxTotalConsumes; // 0x48
        [MetaMember(9, (MetaMemberFlags)0)]
        public int? MaxConsumesPerActivation; // 0x50
        [MetaMember(10, (MetaMemberFlags)0)]
        public MetaActivableCooldownSpec Cooldown; // 0x58
        [MetaMember(11, (MetaMemberFlags)0)]
        public bool AllowActivationAdjustment; // 0x60
        public MetaActivableParams()
        {
        }

        public MetaActivableParams(bool isEnabled, List<MetaRef<PlayerSegmentInfoBase>> segments, List<PlayerCondition> additionalConditions, MetaActivableLifetimeSpec lifetime, bool isTransient, MetaScheduleBase schedule, int? maxActivations, int? maxTotalConsumes, int? maxConsumesPerActivation, MetaActivableCooldownSpec cooldown, bool allowActivationAdjustment)
        {
        }
    }
}