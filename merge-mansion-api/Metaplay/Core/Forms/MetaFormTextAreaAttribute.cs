using System;

namespace Metaplay.Core.Forms
{
    public class MetaFormTextAreaAttribute : MetaFormFieldTypeHintAttribute
    {
        public int Rows { get; set; }
        public int MaxRows { get; set; }
        public override string FieldType { get; }
        public override object FieldTypeProps { get; }

        public MetaFormTextAreaAttribute()
        {
        }
    }
}