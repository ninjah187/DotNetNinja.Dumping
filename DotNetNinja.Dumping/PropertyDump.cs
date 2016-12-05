using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
using System.Text;

namespace DotNetNinja.Dumping
{
    public class PropertyDump : Dump
    {
        public string Name { get; }
        public string Value { get; }

        public PropertyDump(string name, object value, List<Metadata> metadata = null, string typeName = null, 
                            string hashCode = null)
            : base(metadata, typeName, hashCode)
        {
            Name = name;
            Value = value?.ToString() ?? "[null}";
        }
    }
}
