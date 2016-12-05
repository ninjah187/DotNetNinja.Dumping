using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public interface IFluentDumping
    {
        //IFluentDump Dump<TObj>(TObj obj, params Expression<Func<TObj, object>>[] selectors);

        IFluentDumping WithMetadata();
        IFluentDumping WithMemberInfo();
        IFluentDumping WithHashCode();

        string ToString();
        void ToConsole();
    }
}
