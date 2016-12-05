using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public interface IFluentDump
    {
        //IFluentDump Dump<TObj>(TObj obj, params Expression<Func<TObj, object>>[] selectors);

        IFluentDump WithMetadata();
        IFluentDump WithMemberInfo();
        IFluentDump WithHashCode();

        string ToString();
        void ToConsole();
    }
}
