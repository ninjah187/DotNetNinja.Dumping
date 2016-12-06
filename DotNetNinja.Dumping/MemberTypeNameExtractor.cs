using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace DotNetNinja.Dumping
{
    public class MemberTypeNameExtractor : IMemberTypeNameExtractor
    {
        public string GetMemberTypeName(MemberInfo member)
        {
            string memberTypeName = null;

            var memberType = (member as PropertyInfo)?.PropertyType ?? (member as FieldInfo)?.FieldType;
            if (memberType == null)
            {
                throw new MemberInfoException(member, "Unknown MemberInfo type in member type name extraction.");
            }

            var typeInfo = memberType.GetTypeInfo();

            if (typeInfo.IsGenericType)
            {
                var genericDefiniton = memberType.GetGenericTypeDefinition();
                var genericArguments = memberType.GetGenericArguments();

                var genericName = genericDefiniton.Name;
                var separatorIndex = genericName.IndexOf('`');
                genericName = genericName.Remove(separatorIndex, genericName.Length - separatorIndex);

                memberTypeName = $"{genericName}<";

                foreach (var arg in genericArguments)
                {
                    if (arg != genericArguments.Last())
                    {
                        memberTypeName += $"{arg.Name}, ";
                    }
                    else
                    {
                        memberTypeName += $"{arg.Name}>";
                    }
                }
            }
            else
            {
                memberTypeName = memberType.Name;
            }

            if (typeInfo.IsEnum)
            {
                memberTypeName = $"enum {memberTypeName}";
            }

            return memberTypeName;
        }
    }
}
