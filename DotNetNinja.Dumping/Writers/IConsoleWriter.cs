using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public interface IConsoleWriter
    {
        void Write(ObjectDump dump);
    }
}
