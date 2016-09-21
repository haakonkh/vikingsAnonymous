using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
   public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int Age { get; set; }
        public string UserType { get; set; }
            
    }

    public class Threads
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public string Content { get; set; }
        public int CommentsID { get; set; }
        public int UserID { get; set; }

    }

    public class Comments
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int ThreadID { get; set; }
        public List<int> CommentsID { get; set; }

    }

    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Content { get; set; }

    }
}
