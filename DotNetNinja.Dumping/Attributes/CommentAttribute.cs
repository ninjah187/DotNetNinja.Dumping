using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetNinja.Dumping.Attributes
{
    public class CommentAttribute : MetadataAttribute
    {
        public CommentAttribute(string comment)
            : base("Comment", comment)
        {
        }
    }
}
