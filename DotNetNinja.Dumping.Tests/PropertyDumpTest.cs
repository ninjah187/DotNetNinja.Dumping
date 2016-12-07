using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace DotNetNinja.Dumping.Tests
{
    public class PropertyDumpTest
    {
        string _testPropertyName = "testProperty";

        [Fact]
        public void ValueInConstructorIsNull_SetsValueString()
        {
            var dump = new PropertyDump(_testPropertyName, null);

            Assert.Equal("[null]", dump.Value);
        }

        [Fact]
        public void ValueInConstructorIsNotNull_SetsToStringedValue()
        {
            int value = 1;

            var dump = new PropertyDump(_testPropertyName, value);

            Assert.Equal("1", dump.Value);
        }
    }
}
