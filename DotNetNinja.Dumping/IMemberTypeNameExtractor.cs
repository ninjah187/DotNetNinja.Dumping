using System.Reflection;

namespace DotNetNinja.Dumping
{
    public interface IMemberTypeNameExtractor
    {
        string GetMemberTypeName(MemberInfo member);
    }
}