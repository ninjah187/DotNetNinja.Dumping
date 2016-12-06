using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public interface IFluentDumping<TObj>
    {
        IFluentDumping<TObj> WithProperties(params Expression<Func<TObj, object>>[] selectors);

        IFluentDumping<TObj> IncludeMetadata();
        IFluentDumping<TObj> IncludeMemberInfo();
        IFluentDumping<TObj> IncludeHashCode();

        string ToString();
        void ToConsole();
    }
}
