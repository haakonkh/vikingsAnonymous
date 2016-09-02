using MvvmCross.Core.ViewModels;

namespace YWWACP.Core.ViewModels
{
    public class FirstViewModel : MvxViewModel
    {
        private string mTitle;
        private string mCategory;
        private string mContent;

        public string Title{ 
            get { return mTitle; }
            set { mTitle = value; }
        }

        public string Category
        {
            get { return mCategory; }
            set { mCategory = value; }

        }
        public string Content
        {
            get { return mContent; }
            set { mContent = value; }
        }

        /*public FirstViewModel(string title, string category, string content) : base()
        {
            Title = title;
            Category = category;
            Content = content;
        }*/

    }
}
