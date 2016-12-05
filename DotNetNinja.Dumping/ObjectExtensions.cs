using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public static class ObjectExtensions
    {
        public static IFluentDump Dump<TObj>(this TObj obj, params Expression<Func<TObj, object>>[] properties)
        {
            var dumping = new FluentDump<TObj>(obj, new Dumper(), new ConsoleWriter());
            dumping.Dump(properties);
            return dumping;
        }
    }
}
