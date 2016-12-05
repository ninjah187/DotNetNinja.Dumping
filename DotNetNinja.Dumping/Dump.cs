using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class Dump
    {
        public List<Metadata> Metadata { get; }
        public string TypeName { get; }
        public string HashCode { get; }

        public Dump(List<Metadata> metadata = null, string typeName = null, string hashCode = null)
        {
            Metadata = metadata ?? new List<Metadata>();
            TypeName = typeName;
            HashCode = hashCode;
        }
    }
}
