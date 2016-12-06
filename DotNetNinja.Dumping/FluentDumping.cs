using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping
{
    public class FluentDumping<TObj> : IFluentDumping<TObj>
    {
        TObj _obj;
        IDumper _dumper;
        IConsoleWriter _writer;

        DumpDirectives _objectDirectives;
        Dictionary<string, DumpDirectives> _memberDirectives;

        DumpDirectives _directivesBuffer;
        string[] _membersBuffer;

        public FluentDumping(TObj obj, IDumper dumper, IConsoleWriter consoleWriter)
        {
            _obj = obj;
            _dumper = dumper;
            _directivesBuffer = DumpDirectives.None;
            _writer = consoleWriter;
            _memberDirectives = new Dictionary<string, DumpDirectives>();
        }

        public IFluentDumping<TObj> WithProperties(params Expression<Func<TObj, object>>[] selectors)
        {
            FlushBuffer();

            _membersBuffer = selectors.Select(s => ExtractPropertyName(s)).ToArray();
            _directivesBuffer = DumpDirectives.None;

            return this;
        }

        public void ToConsole()
        {
            FlushBuffer();

            var dumpSettings = new ObjectDumpSettings<TObj>(_obj, _objectDirectives, _memberDirectives);

            var dump = _dumper.Dump(dumpSettings);

            _writer.Write(dump);
        }

        public IFluentDumping<TObj> IncludeHashCode()
        {
            _directivesBuffer |= DumpDirectives.HashCode;
            return this;
        }

        public IFluentDumping<TObj> IncludeMemberInfo()
        {
            _directivesBuffer |= DumpDirectives.MemberInfo;
            return this;
        }

        public IFluentDumping<TObj> IncludeMetadata()
        {
            _directivesBuffer |= DumpDirectives.Metadata;
            return this;
        }

        void FlushBuffer()
        {
            if (_membersBuffer == null)
            {
                if (_directivesBuffer != DumpDirectives.None)
                {
                    _objectDirectives = _directivesBuffer;
                    _directivesBuffer = DumpDirectives.None;
                }
                return;
            }

            foreach (var member in _membersBuffer)
            {
                _memberDirectives.Add(member, _directivesBuffer);
            }

            _membersBuffer = null;
            _directivesBuffer = DumpDirectives.None;
        }

        string ExtractPropertyName(Expression<Func<TObj, object>> expression)
        {
            var unaryExpression = expression.Body as UnaryExpression;
            var memberExpression = unaryExpression?.Operand as MemberExpression ?? expression.Body as MemberExpression;
            return memberExpression.Member.Name;
        }
    }
}
