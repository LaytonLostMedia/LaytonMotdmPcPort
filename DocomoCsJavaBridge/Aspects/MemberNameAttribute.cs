namespace DocomoCsJavaBridge.Aspects
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class MemberNameAttribute : Attribute
    {
        public string Name { get; }

        public MemberNameAttribute(string name)
        {
            Name = name;
        }
    }
}
