using System;
using DotNetNinja.Dumping;

namespace DotNetNinja.Dumping.Samples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            StandardOutput.Simple();
            StandardOutput.Verbose();

            Json.Simple();
            Json.Verbose();

            Console.ReadKey();
        }
    }
}
