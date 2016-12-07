using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace DotNetNinja.Dumping
{
    public static class ObjectExtensions
    {
        public static IFluentDumping<TObj> Dump<TObj>(this TObj obj)
        {
            var dumping = new FluentDumping<TObj>(obj, 
                                                  new Dumper(new MemberTypeNameExtractor()), 
                                                  new ConsoleWriter(),
                                                  new JsonWriter(new JsonSerializerSettings
                                                  {
                                                      Formatting = Formatting.Indented,
                                                      DefaultValueHandling = DefaultValueHandling.Ignore,
                                                      ContractResolver = new CamelCasePropertyNamesContractResolver()
                                                  }));
            return dumping;
        }
    }
}
