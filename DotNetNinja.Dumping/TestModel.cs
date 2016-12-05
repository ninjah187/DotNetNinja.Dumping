using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetNinja.Dumping.Attributes;

namespace DotNetNinja.Dumping
{
    public class TestModel
    {
        [Comment("Test comment about a property.")]
        [Metadata("Custom metadata", "Some custom metadata attribute.")]
        public int Integer { get; set; }
        
        public string String { get; set; }
    }
}
