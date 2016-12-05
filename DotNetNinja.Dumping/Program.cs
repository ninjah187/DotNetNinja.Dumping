using System;

namespace DotNetNinja.Dumping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var model = new TestModel();

            model
                .Dump(m => m.Integer)
                .WithMemberInfo()
                .WithMetadata()
                .ToConsole();

            Console.ReadKey();
        }
    }
}
