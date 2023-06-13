namespace merge_mansion_update.Il2CppBinary.Attributes
{
    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true)]
    class VersionAttribute : Attribute
    {
        public double Min { get; set; } = 0;
        public double Max { get; set; } = 99;
    }
}