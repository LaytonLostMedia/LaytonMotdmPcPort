using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocomoCsJavaBridge.Aspects
{
    [AttributeUsage(AttributeTargets.Method)]
    public class FunctionNameAttribute : Attribute
    {
        public string Name { get; }

        public FunctionNameAttribute(string name)
        {
            Name = name;
        }
    }
}
