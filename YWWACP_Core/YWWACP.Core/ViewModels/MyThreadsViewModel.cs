using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class MyThreadsViewModel : MvxViewModel
    {
        private readonly IDatabase database;
        public ICommand AddNewThreadCommand { get; set; }
        public ICommand AllThreadsCommand { get; set; }
        public ICommand SelectThreadCommand { get; set; }

        private ObservableCollection<NewDiscussionThread> myThreads = new ObservableCollection<NewDiscussionThread>();

        public ObservableCollection<NewDiscussionThread> MyThreads
        {
            get { return myThreads; }
            set { SetProperty(ref myThreads, value); }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public MyThreadsViewModel(IDatabase database)
        {
            this.database = database;
            AddNewThreadCommand = new MvxCommand(() => ShowViewModel<CreateNewThreadViewModel>(new { userid = UserId }));
            SelectThreadCommand = new MvxCommand<NewDiscussionThread>(thread => ShowViewModel<CommentsViewModel>(new { threadID = thread.ThreadID }));
            AllThreadsCommand = new MvxCommand(() =>
            {
                ShowViewModel<CommunityViewModel>(new {userid = UserId});
                Close(this);
            });
            
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public void OnResume()
        {
            GetMyThreads();
        }

        public async void GetMyThreads()
        {
            var getMyThreads = await database.GetTable();
            MyThreads.Clear();
            foreach (var thread in getMyThreads)
            {
                var c = thread.Content;
                var i = thread.UserId;

                if (thread.Content != null && thread.UserId == UserId)
                {
                    MyThreads.Insert(0, new NewDiscussionThread(thread.ThreadTitle, thread.Category, thread.Content, thread.ThreadID));
                }
            }
            RaisePropertyChanged(() => MyThreads);
        }
    }
}