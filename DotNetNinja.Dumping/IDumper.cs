using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public interface IDumper
    {
        ObjectDump Dump<TObj>(TObj obj, DumpDirectives directives, params Expression<Func<TObj, object>>[] properties);
    }
}
