using Metaplay.Core.Forms;
using System;

namespace Game.Cloud.Localization
{
    public class GridlyBranchFieldTypeHintAttribute : MetaFormFieldTypeHintAttribute
    {
        public override string FieldType { get; }
        public override object FieldTypeProps { get; }

        public GridlyBranchFieldTypeHintAttribute()
        {
        }
    }
}