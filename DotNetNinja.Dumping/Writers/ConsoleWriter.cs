﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class ConsoleWriter : IConsoleWriter
    {
        public void Write(ObjectDump dump)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("@ object:");
            WriteDump(dump, 2);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("@ properties:");
            foreach (var property in dump.Properties)
            {
                WriteProperty(property, 0);
            }
            Console.WriteLine("@ fields:");
            foreach (var field in dump.Fields)
            {
                WriteField(field, 0);
            }
            Console.WriteLine("---");

            Console.ResetColor();
        }

        void WriteProperty(PropertyDump property, int indentationLevel)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"+ {property.Name}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{property.Value}");

            WriteDump(property, 2);
        }

        void WriteField(FieldDump field, int indentationLevel)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"+ {field.Name}: ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{field.Value}");

            WriteDump(field, 2);
        }

        void WriteDump(Dump dump, int indentationLevel)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            var indentation = GetIndentation(indentationLevel);

            if (dump.HashCode != null)
            {
                Console.WriteLine($"{indentation}$ hashCode: {dump.HashCode}");
            }

            if (dump.TypeName != null)
            {
                Console.WriteLine($"{indentation}$ type: {dump.TypeName}");
            }

            if (dump.Metadata != null)
            {
                foreach (var metadata in dump.Metadata)
                {
                    Console.WriteLine($"{indentation}> {metadata.Key}: {metadata.Value}");
                }
            }
        }

        string GetIndentation(int indentationLevel)
        {
            var indentation = "";
            for (int i = 0; i < indentationLevel; i++)
            {
                indentation += " ";
            }
            return indentation;
        }
    }
}
