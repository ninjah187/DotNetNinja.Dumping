using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public interface IFluentDumping<TObj>
    {
        IFluentDumping<TObj> And(params Expression<Func<TObj, object>>[] selectors);

        IFluentDumping<TObj> WithMetadata();
        IFluentDumping<TObj> WithMemberInfo();
        IFluentDumping<TObj> WithHashCode();

        string ToString();
        void ToConsole();
    }
}
