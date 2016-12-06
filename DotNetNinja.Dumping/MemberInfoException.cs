using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace DotNetNinja.Dumping
{
    public class MemberInfoException : Exception
    {
        public MemberInfo MemberInfo { get; }

        public MemberInfoException(MemberInfo memberInfo, string message = null)
            : base(message)
        {
            MemberInfo = memberInfo;
        }
    }
}
