using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocomoCsJavaBridge.Aspects
{
    [AttributeUsage(AttributeTargets.Constructor)]
    public class ConstructorNameAttribute:Attribute
    {
        public string Name { get; }

        public ConstructorNameAttribute(string name)
        {
            Name = name;
        }
    }
}
