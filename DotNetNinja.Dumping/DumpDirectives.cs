using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    [Flags]
    public enum DumpDirectives
    {
        None        = 0,
        MemberInfo  = 1 << 0,
        Metadata    = 1 << 1,
        HashCode    = 1 << 2
    }
}
