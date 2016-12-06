using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public interface IDumper
    {
        ObjectDump Dump<TObj>(ObjectDumpSettings<TObj> settings);
    }
}
