using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public static class ObjectExtensions
    {
        //public static IFluentDumping<TObj> Dump<TObj>(this TObj obj, params Expression<Func<TObj, object>>[] properties)
        //{
        //    var dumping = new FluentDumping<TObj>(obj, new Dumper(), new ConsoleWriter());
        //    dumping.Dump(properties);
        //    return dumping;
        //}

        public static IFluentDumping<TObj> Dump<TObj>(this TObj obj)
        {
            var dumping = new FluentDumping<TObj>(obj, new Dumper(), new ConsoleWriter());
            return dumping;
        }
    }
}
