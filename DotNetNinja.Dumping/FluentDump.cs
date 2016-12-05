using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class FluentDump<TObj> : IFluentDump
    {
        TObj _obj;
        IDumper _dumper;
        DumpDirectives _directives;
        IConsoleWriter _writer;
        Expression<Func<TObj, object>>[] _properties;

        public FluentDump(TObj obj, IDumper dumper, IConsoleWriter consoleWriter)
        {
            _obj = obj;
            _dumper = dumper;
            _directives = DumpDirectives.None;
            _writer = consoleWriter;
        }

        public IFluentDump Dump(params Expression<Func<TObj, object>>[] properties)
        {
            _properties = properties;
            return this;
        }

        public void ToConsole()
        {
            _writer.Write(_dumper.Dump(_obj, _directives, _properties));
        }

        public IFluentDump WithHashCode()
        {
            _directives |= DumpDirectives.HashCode;
            return this;
        }

        public IFluentDump WithMemberInfo()
        {
            _directives |= DumpDirectives.MemberInfo;
            return this;
        }

        public IFluentDump WithMetadata()
        {
            _directives |= DumpDirectives.Metadata;
            return this;
        }
    }
}
