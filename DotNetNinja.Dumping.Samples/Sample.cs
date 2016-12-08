using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping.Samples
{
    public static class Sample
    {
        public static TestModel Model { get; } = new TestModel
        {
            String = "The Answer",
            Integer = 42
        };
    }
}
