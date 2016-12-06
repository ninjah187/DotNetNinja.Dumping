using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class MetadataAttribute : Attribute
    {
        public Metadata Metadata { get; }

        public MetadataAttribute(string key, string value)
        {
            Metadata = new Metadata(key, value);
        }
    }
}
