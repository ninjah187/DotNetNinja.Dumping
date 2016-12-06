using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class FieldDump : Dump
    {
        public string Name { get; }
        public string Value { get; }

        public FieldDump(string name, object value, List<Metadata> metadata = null, string typeName = null,
                            string hashCode = null)
            : base(metadata, typeName, hashCode)
        {
            Name = name;
            Value = value?.ToString() ?? "[null]";
        }
    }
}
