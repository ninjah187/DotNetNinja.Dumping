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

        IConsoleWriter _consoleWriter;
        IJsonWriter _jsonWriter;

        DumpDirectives _objectDirectives;
        Dictionary<string, DumpDirectives> _memberDirectives;

        DumpDirectives _directivesBuffer;
        string[] _membersBuffer;

        public FluentDumping(TObj obj, IDumper dumper, IConsoleWriter consoleWriter, IJsonWriter jsonWriter)
        {
            _obj = obj;
            _dumper = dumper;
            _directivesBuffer = DumpDirectives.None;
            _consoleWriter = consoleWriter;
            _jsonWriter = jsonWriter;
            _memberDirectives = new Dictionary<string, DumpDirectives>();
        }

        public IFluentDumping<TObj> WithProperties(params Expression<Func<TObj, object>>[] selectors)
        {
            FlushBuffer();

            _membersBuffer = selectors.Select(s => ExtractPropertyName(s)).ToArray();
            _directivesBuffer = DumpDirectives.None;

            return this;
        }

        public IFluentDumping<TObj> WithFields(params string[] fields)
        {
            FlushBuffer();

            _membersBuffer = fields;
            _directivesBuffer = DumpDirectives.None;

            return this;
        }

        public void ToConsole()
        {
            var dump = Dump();

            _consoleWriter.Write(dump);
        }

        public string ToJson()
            => _jsonWriter.Write(Dump());

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

        ObjectDump Dump()
        {
            FlushBuffer();

            var dumpSettings = new ObjectDumpSettings<TObj>(_obj, _objectDirectives, _memberDirectives);

            var dump = _dumper.Dump(dumpSettings);

            return dump;
        }

        void FlushBuffer()
        {
            if (_membersBuffer == null)
            {
                if (_directivesBuffer != DumpDirectives.None)
                {
                    _objectDirectives = _directivesBuffer;
                }
                _directivesBuffer = DumpDirectives.None;
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
