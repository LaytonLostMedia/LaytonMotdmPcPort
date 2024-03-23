namespace DocomoCsJavaBridge.Aspects
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface)]
    public class ClassNameAttribute : Attribute
    {
        public string Package { get; }
        public string Name { get; }

        public ClassNameAttribute(string nameSpace, string name)
        {
            Package = nameSpace;
            Name = name;
        }
    }
}
