using System;

namespace DotNetNinja.Dumping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var model = new TestModel()
            {
                Integer = 42,
                String = "The Answer"
            };

            // tiny dump:
            model
                .Dump()
                .WithProperties(x => x.String, x => x.Integer)
                .WithFields("_hiddenValue")
                .ToConsole();

            // verbose dump:
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

            Console.ReadKey();
        }
    }
}
