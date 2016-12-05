using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class ObjectDump : Dump
    {
        public List<PropertyDump> Properties { get; }

        public ObjectDump(List<PropertyDump> properties = null, List<Metadata> metadata = null, string typeName = null,
                          string hashCode = null)
            : base(metadata, typeName, hashCode)
        {
            Properties = properties;
        }
    }
}
