using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
    public class Comment
    {
        public string CommentContent { get; set; }
        public Comment() { }

        public Comment(string comment)
        {
            CommentContent = comment;
        }

    }
    
}
