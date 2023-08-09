using Metaplay.Core.Json;
using System.ComponentModel;
using Metaplay.Core.Model;

namespace GameLogic
{
    [TypeConverter(typeof(EnumStringConverter<MassMailIdenfiers>))]
    [MetaSerializable]
    public enum MassMailIdenfiers
    {
        None = 0,
        December2020PatchIssueApology = 1,
        FirstEventProgressApologyForLevel20 = 2,
        GardenRightRedesignRebate2021 = 3
    }
}