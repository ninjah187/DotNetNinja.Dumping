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
                    .IncludeMemberInfo()
                .And(m => m.String)
                .ToConsole();

            Console.ReadKey();
        }
    }
}
