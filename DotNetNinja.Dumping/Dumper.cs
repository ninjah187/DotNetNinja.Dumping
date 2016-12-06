using System;
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
        public ObjectDump Dump<TObj>(ObjectDumpSettings<TObj> settings)
        {
            var directives = settings.ObjectDirectives;
            var obj = settings.Object;
            var properties = DumpProperties(settings.Object, settings.MemberDirectives).ToList();
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
                    propertyTypeName = GetPropertyTypeName(property);
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
                    hashCode = obj.GetHashCode().ToString();
                }

                yield return new PropertyDump(memberName, propertyValue, metadata, propertyTypeName, hashCode);
            }
        }

        string GetPropertyTypeName(PropertyInfo property)
        {
            string propertyTypeName = null;

            var typeInfo = property.PropertyType.GetTypeInfo();

            if (typeInfo.IsGenericType)
            {
                var genericDefiniton = property.PropertyType.GetGenericTypeDefinition();
                var genericArguments = property.PropertyType.GetGenericArguments();

                var genericName = genericDefiniton.Name;
                var separatorIndex = genericName.IndexOf('`');
                genericName = genericName.Remove(separatorIndex, genericName.Length - separatorIndex);

                propertyTypeName = $"{genericName}<";

                foreach (var arg in genericArguments)
                {
                    if (arg != genericArguments.Last())
                    {
                        propertyTypeName += $"{arg.Name}, ";
                    }
                    else
                    {
                        propertyTypeName += $"{arg.Name}>";
                    }
                }
            }
            else
            {
                propertyTypeName = property.PropertyType.Name;
            }
            
            if (typeInfo.IsEnum)
            {
                propertyTypeName = $"enum {propertyTypeName}";
            }

            return propertyTypeName;
        }
    }
}
