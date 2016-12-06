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
        Dictionary<Expression<Func<TObj, object>>[], DumpDirectives> _settings;

        DumpDirectives _directivesBuffer;
        Expression<Func<TObj, object>>[] _selectorsBuffer;

        public FluentDumping(TObj obj, IDumper dumper, IConsoleWriter consoleWriter)
        {
            _obj = obj;
            _dumper = dumper;
            _directivesBuffer = DumpDirectives.None;
            _writer = consoleWriter;
            _settings = new Dictionary<Expression<Func<TObj, object>>[], DumpDirectives>();
        }

        public IFluentDumping<TObj> Dump(params Expression<Func<TObj, object>>[] selectors)
        {
            _selectorsBuffer = selectors;
            _directivesBuffer = DumpDirectives.None;
            return this;
        }

        public void ToConsole()
        {
            if (_selectorsBuffer != null)
            {
                _settings.Add(_selectorsBuffer, _directivesBuffer);
            }

            //_writer.Write(_dumper.Dump(_obj, _di, _properties));
            foreach (var setting in _settings)
            {
                _writer.Write(_dumper.Dump(_obj, setting.Value, setting.Key));
            }
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

        public IFluentDumping<TObj> And(params Expression<Func<TObj, object>>[] selectors)
        {
            _settings.Add(_selectorsBuffer, _directivesBuffer);
            _selectorsBuffer = selectors;
            _directivesBuffer = DumpDirectives.None;
            return this;
        }
    }
}
