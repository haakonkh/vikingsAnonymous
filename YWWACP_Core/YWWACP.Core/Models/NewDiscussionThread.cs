using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
    public class NewDiscussionThread
    {
        public string Title { get; set; }

        public string Category { get; set; }

        public string Content { get; set; }
        public string ThreadID { get; set; }

        public NewDiscussionThread() { }
        public NewDiscussionThread(string title, string category, string content, string id)
        {
            Title = title;
            Category = category;
            Content = content;
            ThreadID = id;
        }
    }
}
