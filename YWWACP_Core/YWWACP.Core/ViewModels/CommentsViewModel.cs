using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class CommentsViewModel : MvxViewModel
    {
        private readonly IDatabase database;
        private ObservableCollection<Comment>  comments = new ObservableCollection<Comment>();

        private string threadID;

        public string ThreadID
        {
            get { return threadID; }
            set
            {
                threadID = value;
                RaisePropertyChanged(() => ThreadID);
            }
        }

        private string threadContent;

        public string ThreadContent
        {
            get { return threadContent;}
            set { SetProperty(ref threadContent, value); }
        }


        public ObservableCollection<Comment> Comments
        {
            get { return comments;}
            set { SetProperty(ref comments, value); }
        }

        public ICommand AddCommentCommand { get; set; }
        
        public CommentsViewModel(IDatabase database )
        {
            this.database = database;
            AddCommentCommand = new MvxCommand(() => ShowViewModel<WriteCommentViewModel>(new {tId = ThreadID}));   
        }

        public void Init(string threadID)
        {
            ThreadID = threadID;
        }

        public void OnResume()
        {
            GetComments();
        }

        public async void GetComments()
        {
            SetThreadContentOnComments();
            var loadComments = await database.GetTable();
            Comments.Clear();

            foreach (var comment in loadComments)
            {
                if (comment.CommentContent != null)
                {
                    if (ThreadID == comment.ThreadID)
                    {
                        Comments.Add(new Comment(comment.CommentContent));
                    }
                }
            }
            RaisePropertyChanged(() => Comments);
        }

        /// <summary>
        /// Sets thread content on top of the screen
        /// Gets called innside GetComments
        /// </summary>
        private async void SetThreadContentOnComments()
        {
            var loadThreads = await database.GetTable();
            foreach (var threads in loadThreads)
            {
                if (ThreadID == threads.ThreadID)
                {
                    ThreadContent = threads.Content;
                    break;
                }
                RaisePropertyChanged(() => ThreadContent);
            }
        }
    }
}
