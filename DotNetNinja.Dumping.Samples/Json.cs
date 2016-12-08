using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping.Samples
{
    public static class Json
    {
        public static void Simple()
        {
            var model = Sample.Model;

            var json = model
                .Dump()
                .WithProperties(x => x.String, x => x.Integer)
                .WithFields("_hiddenValue")
                .ToJson();

            Console.WriteLine(json);

            // sample JSON dump:
            /*
                {
                  "properties": [
                    {
                      "name": "String",
                      "value": "The Answer"
                    },
                    {
                      "name": "Integer",
                      "value": "42"
                    }
                  ],
                  "fields": [
                    {
                      "name": "_hiddenValue",
                      "value": "0,07"
                    }
                  ]
                } 
             */
        }

        public static void Verbose()
        {
            var model = Sample.Model;

            var json = model
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
                .ToJson();

            Console.WriteLine(json);

            // sample JSON dump:
            /*
                {
                  "properties": [
                    {
                      "name": "String",
                      "value": "The Answer",
                      "metadata": [
                        {
                          "key": "Comment",
                          "value": "The Answer to the Ultimate Question of Life, The Universe, and Everything."
                        }
                      ],
                      "typeName": "String",
                      "hashCode": "1339544504"
                    },
                    {
                      "name": "Integer",
                      "value": "42",
                      "metadata": [
                        {
                          "key": "Comment",
                          "value": "Test comment about a property."
                        },
                        {
                          "key": "Custom metadata",
                          "value": "Some custom metadata attribute."
                        }
                      ],
                      "typeName": "Int32",
                      "hashCode": "42"
                    }
                  ],
                  "fields": [
                    {
                      "name": "_hiddenValue",
                      "value": "0,07",
                      "metadata": [
                        {
                          "key": "Note",
                          "value": "Remarks here."
                        }
                      ],
                      "typeName": "Double",
                      "hashCode": "554285673"
                    }
                  ],
                  "metadata": [
                    {
                      "key": "Content",
                      "value": "Discover by yourself."
                    }
                  ],
                  "typeName": "DotNetNinja.Dumping.TestModel",
                  "hashCode": "59941933"
                }
             */
        }
    }
}
