using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping.Samples
{
    public static class StandardOutput
    {
        public static void Simple()
        {
            var model = Sample.Model;

            model
                .Dump()
                .WithProperties(x => x.String, x => x.Integer)
                .WithFields("_hiddenValue")
                .ToConsole();

            // writes to standard output:
            //
            // @ object:
            // @ properties:
            // +String: The Answer
            // +Integer: 42
            // @ fields:
            // +_hiddenValue: 0,07
            // ---
            //
        }

        public static void Verbose()
        {
            var model = Sample.Model;

            model
                .Dump()
                    .IncludeHashCode()
                    .IncludeMemberInfo()
                    .IncludeMetadata()
                .WithProperties(x => x.String, x => x.Integer)
                    .IncludeHashCode()
                    .IncludeMemberInfo()
                    .IncludeMetadata()
                .WithFields("_hiddenValue")
                    .IncludeHashCode()
                    .IncludeMemberInfo()
                    .IncludeMetadata()
                .ToConsole();

            //  sample dump written to standard output:
            //
            // @ object:
            //   $ hashCode: 59941933
            //   $ type: DotNetNinja.Dumping.TestModel
            //   > Content: Discover by yourself.
            // @ properties:
            // +String: The Answer
            //   $ hashCode: 8827605
            //   $ type: String
            //   > Comment: The Answer to the Ultimate Question of Life, The Universe, and Everything.
            // +Integer: 42
            //   $ hashCode: 42
            //   $ type: Int32
            //   > Comment: Test comment about a property.
            //   > Custom metadata: Some custom metadata attribute.
            // @ fields:
            //   +_hiddenValue: 0,07
            //   $ hashCode: 554285673
            //   $ type: Double
            //   > Note: Remarks here.
            // ---
            //
        }
    }
}
