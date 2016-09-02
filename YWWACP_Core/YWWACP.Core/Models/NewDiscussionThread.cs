using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace YWWACP
{
   public class NewDiscussionThread
    {
        public string Title {get; set;}

        public string Category { get; set; }

        public string Content { get; set; }

        public NewDiscussionThread(){}
        public NewDiscussionThread(string title, string category, string content)
        {
            Title = title;
            Category = category;
            Content = content;       
        }
    }
}