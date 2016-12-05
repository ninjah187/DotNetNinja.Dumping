using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(ObjectDump dump)
        {
            WriteDump(dump);
            Console.WriteLine("$ properties:");
            foreach (var property in dump.Properties)
            {
                WriteProperty(property);
            }

            Console.ResetColor();
        }

        void WriteProperty(PropertyDump property)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"+ {property.Name}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{property.Value}");

            WriteDump(property);
        }

        void WriteDump(Dump dump)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            if (dump.HashCode != null)
            {
                Console.WriteLine($"$ hashCode: {dump.HashCode}");
            }

            if (dump.TypeName != null)
            {
                Console.WriteLine($"$ type: {dump.TypeName}");
            }

            foreach (var metadata in dump.Metadata)
            {
                Console.WriteLine($"  > {metadata.Key}: {metadata.Value}");
            }

            if (dump.Metadata.Count != 0)
            {
                Console.WriteLine(" ---");
            }
        }
    }
}
