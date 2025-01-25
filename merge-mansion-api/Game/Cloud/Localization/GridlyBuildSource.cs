using Metaplay.Core.Model;
using Metaplay.Core.Config;
using Metaplay.Core.Forms;
using System;

namespace Game.Cloud.Localization
{
    [MetaSerializableDerived(200)]
    public class GridlyBuildSource : GameConfigBuildSource
    {
        [MetaMember(1, (MetaMemberFlags)0)]
        [MetaFormNotEditable]
        public string Name { get; set; }

        [MetaMember(2, (MetaMemberFlags)0)]
        [GridlyBranchFieldTypeHint]
        [MetaValidateRequired]
        public string Branch { get; set; }
        public override string DisplayName { get; }

        private GridlyBuildSource()
        {
        }

        public GridlyBuildSource(string name, string branch)
        {
        }
    }
}