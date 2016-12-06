using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotNetNinja.Dumping.Attributes;

namespace DotNetNinja.Dumping
{
    [Metadata("Content", "Discover by yourself.")]
    public class TestModel
    {
        [Comment("Test comment about a property.")]
        [Metadata("Custom metadata", "Some custom metadata attribute.")]
        public int Integer { get; set; }
        
        [Comment("The Answer to the Ultimate Question of Life, The Universe, and Everything.")]
        public string String { get; set; }

        [Metadata("Note", "Remarks here.")]
        double _hiddenValue = 0.07;
    }
}
