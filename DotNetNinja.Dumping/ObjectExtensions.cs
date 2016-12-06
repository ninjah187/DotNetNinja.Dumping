using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public static class ObjectExtensions
    {
        public static IFluentDumping<TObj> Dump<TObj>(this TObj obj)
        {
            var dumping = new FluentDumping<TObj>(obj, new Dumper(new MemberTypeNameExtractor()), new ConsoleWriter());
            return dumping;
        }
    }
}
