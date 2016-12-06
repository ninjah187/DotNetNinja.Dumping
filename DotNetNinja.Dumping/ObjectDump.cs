using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class ObjectDump : Dump
    {
        public IEnumerable<PropertyDump> Properties { get; }
        public IEnumerable<FieldDump> Fields { get; }

        public ObjectDump(IEnumerable<PropertyDump> properties = null, IEnumerable<FieldDump> fields = null, List<Metadata> metadata = null,
                          string typeName = null, string hashCode = null)
            : base(metadata, typeName, hashCode)
        {
            Properties = properties;
            Fields = fields;
        }
    }
}
