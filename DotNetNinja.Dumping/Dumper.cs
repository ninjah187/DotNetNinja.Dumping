﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Reflection;
using System.Text;
using DotNetNinja.Dumping.Attributes;

namespace DotNetNinja.Dumping
{
    public class Dumper : IDumper
    {
        IMemberTypeNameExtractor _typeNameExtractor;

        public Dumper(IMemberTypeNameExtractor typeNameExtractor)
        {
            _typeNameExtractor = typeNameExtractor;
        }

        public ObjectDump Dump<TObj>(ObjectDumpSettings<TObj> settings)
        {
            var directives = settings.ObjectDirectives;
            var obj = settings.Object;
            var properties = DumpProperties(settings.Object, settings.MemberDirectives).ToList();
            var fields = DumpFields(settings.Object, settings.MemberDirectives).ToList();
            string objectTypeName = null;
            List<Metadata> objectMetadata = null;

            if ((directives & DumpDirectives.MemberInfo) == DumpDirectives.MemberInfo)
            {
                objectTypeName = typeof(TObj).ToString();
            }

            if ((directives & DumpDirectives.Metadata) == DumpDirectives.Metadata)
            {
                objectMetadata = typeof(TObj).GetTypeInfo()
                    .GetCustomAttributes<MetadataAttribute>()
                    .Select(a => a.Metadata)
                    .ToList();
            }

            return new ObjectDump(
                    properties: properties,
                    fields: fields,
                    metadata: objectMetadata,
                    typeName: objectTypeName,
                    hashCode: directives.HasFlag(DumpDirectives.HashCode) ? obj.GetHashCode().ToString() : null
                );
        }

        IEnumerable<PropertyDump> DumpProperties<TObj>(TObj obj, Dictionary<string, DumpDirectives> memberDirectives)
        {
            foreach (var keyValue in memberDirectives)
            {
                var memberName = keyValue.Key;
                var directives = keyValue.Value;
                
                var property = typeof(TObj).GetProperty(memberName);
                if (property == null)
                {
                    continue;
                }

                var propertyValue = property.GetValue(obj);
                string propertyTypeName = null;
                List<Metadata> metadata = null;
                string hashCode = null;

                if ((directives & DumpDirectives.MemberInfo) == DumpDirectives.MemberInfo)
                {
                    propertyTypeName = _typeNameExtractor.GetMemberTypeName(property);
                }

                if ((directives & DumpDirectives.Metadata) == DumpDirectives.Metadata)
                {
                    metadata = property
                        .GetCustomAttributes<MetadataAttribute>()
                        .Select(a => a.Metadata)
                        .ToList();
                }

                if (directives.HasFlag(DumpDirectives.HashCode))
                {
                    hashCode = propertyValue?.GetHashCode().ToString();
                }

                yield return new PropertyDump(memberName, propertyValue, metadata, propertyTypeName, hashCode);
            }
        }

        IEnumerable<FieldDump> DumpFields<TObj>(TObj obj, Dictionary<string, DumpDirectives> memberDirectives)
        {
            foreach (var keyValue in memberDirectives)
            {
                var memberName = keyValue.Key;
                var directives = keyValue.Value;

                var field = typeof(TObj).GetField(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (field == null)
                {
                    continue;
                }

                var fieldValue = field.GetValue(obj);
                string fieldTypeName = null;
                List<Metadata> metadata = null;
                string hashCode = null;
                
                if ((directives & DumpDirectives.MemberInfo) == DumpDirectives.MemberInfo)
                {
                    fieldTypeName = _typeNameExtractor.GetMemberTypeName(field);
                }

                if ((directives & DumpDirectives.Metadata) == DumpDirectives.Metadata)
                {
                    metadata = field
                        .GetCustomAttributes<MetadataAttribute>()
                        .Select(a => a.Metadata)
                        .ToList();
                }

                if (directives.HasFlag(DumpDirectives.HashCode))
                {
                    hashCode = fieldValue?.GetHashCode().ToString();
                }

                yield return new FieldDump(memberName, fieldValue, metadata, fieldTypeName, hashCode);
            }
        }
    }
}
