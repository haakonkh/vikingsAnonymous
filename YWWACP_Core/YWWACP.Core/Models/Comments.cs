using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
    // ## Name: Andreas Norstein | ## Student number: 9805061

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
