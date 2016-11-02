using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Community
{
    // ## Name: Andreas Norstein | ## Student number: 9805061
    public class CommentsViewModel : MvxViewModel
    {
        private readonly IDatabase database;
        private readonly IDialogService dialog;
        private ObservableCollection<Comment>  comments = new ObservableCollection<Comment>();
        public ICommand DeletePopupCommand { get; set; }


        private string userId;
        public string UserId { get { return userId; } set { SetProperty(ref userId, value); } }
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
        
        public CommentsViewModel(IDatabase database, IDialogService dialog)
        {
            this.database = database;
            this.dialog = dialog;
            AddCommentCommand = new MvxCommand(() => ShowViewModel<WriteCommentViewModel>(new {tId = ThreadID}));
            DeletePopupCommand = new MvxCommand(() =>
            {
                DeleteThread();
            });

        }

        public void Init(string threadID, string userid)
        {
            ThreadID = threadID;
            UserId = userid;
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

        public async Task<bool> VerifyUser()
        {
            var users = await database.GetTable();
            return users.Any(user => user.UserId == UserId && user.ThreadID == ThreadID);
        }

        public async void DeleteThread()
        {
            if (await VerifyUser())
            {
                if (await dialog.Show("Are you sure you want to delete this question?", "Delete Question?", "Delete", "Cancel"))
                {
                    var threads = await database.GetTable();
                    foreach (var thread in threads)
                    {
                        if (thread.ThreadID == ThreadID)
                        {
                            await database.DeleteTableRow(thread.Id);
                        }
                    }
                    Close(this);
                }
                else
                {
                    return;
                }
            }
            else
            {
                Mvx.Resolve<IToast>().Show("You are not allowed to delete other people's threads");
            }

        }
    }
}
