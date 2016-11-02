using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using YWWACP.Core.ViewModels.Diary;
using YWWACP.Core.ViewModels.ExerciseRecipe;
using YWWACP.Core.ViewModels.Goal;

namespace YWWACP.Core.ViewModels.Community
{
    // ## Name: Andreas Norstein | ## Student number: 9805061

    public class CommunityViewModel : MvxViewModel
    {
        // Everyone should include these commands on their pages
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenRecipesCommand { get; set; }
        public ICommand OpenDiaryCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }


        // Specific for this class
        private readonly IDatabase database;
        public ICommand AddNewThreadCommand { get; set; }
        public ICommand MyThreadsCommand { get; set; }
        public ICommand SelectThreadCommand { get; set; }

        private ObservableCollection<NewDiscussionThread> newThreads = new ObservableCollection<NewDiscussionThread>();

        public ObservableCollection<NewDiscussionThread> NewThreads
        {
            get { return newThreads; }
            set { SetProperty(ref newThreads, value); }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }


        public CommunityViewModel(IDatabase database)
        {
            this.database = database;
            AddNewThreadCommand = new MvxCommand(() => ShowViewModel<CreateNewThreadViewModel>(new { userid = UserId }));
            SelectThreadCommand = new MvxCommand<NewDiscussionThread>(thread => ShowViewModel<CommentsViewModel>(new { threadID = thread.ThreadID, userid = UserId }));
            MyThreadsCommand = new MvxCommand(() =>
            {
                ShowViewModel<MyThreadsViewModel>(new { userid = UserId });
                Close(this);
            });
            
            OpenHealthPlanCommand = new MvxCommand(() =>
            {
                ShowViewModel<HealthPlanViewModel>(new { userid = UserId});
                Close(this);
            });
            OpenDiaryCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenHomeCommand = new MvxCommand(() =>
            {
                ShowViewModel<GraphViewModel>(new {userid = UserId});
                Close(this);
            });
            OpenRecipesCommand = new MvxCommand(() =>
            {
                ShowViewModel<RecipeViewModel>(new {userid = UserId});
                Close(this);
            });
            OpenExerciseCommand = new MvxCommand(() =>
            {
                ShowViewModel<CreateNewGViewModel>(new {userid = UserId});
                Close(this);
            });
            
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public void OnResume()
        {
            GetThreads();
        }

        public async void GetThreads()
        {
            var threads = await database.GetTable();
            NewThreads.Clear();
            foreach (var thread in threads)
            {
                var c = thread.Content;

                if (thread.Content != null)
                {
                    NewThreads.Insert(0, new NewDiscussionThread(thread.ThreadTitle, thread.Category, thread.Content, thread.ThreadID));
                }
            }

            RaisePropertyChanged(() => NewThreads);

        }

    }

}
