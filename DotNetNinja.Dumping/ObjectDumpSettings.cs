using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class ObjectDumpSettings<TObj>
    {
        public TObj Object { get; }
        public DumpDirectives ObjectDirectives { get; }

        // key: member name, value: directives
        public Dictionary<string, DumpDirectives> MemberDirectives { get; }

        public ObjectDumpSettings(TObj obj, DumpDirectives objDirectives, Dictionary<string, DumpDirectives> memberDirectives = null)
        {
            Object = obj;
            ObjectDirectives = objDirectives;
            MemberDirectives = memberDirectives ?? new Dictionary<string, DumpDirectives>();
        }
    }
}
