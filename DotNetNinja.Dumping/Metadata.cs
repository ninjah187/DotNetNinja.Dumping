using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class Metadata
    {
        public string Key { get; }
        public string Value { get; }

        public Metadata(string key, string value)
        {
            Key = key;
            Value = value;
        }
    }
}
