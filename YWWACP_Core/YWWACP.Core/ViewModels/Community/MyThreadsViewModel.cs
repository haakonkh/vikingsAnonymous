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

    public class MyThreadsViewModel : MvxViewModel
    {

        // Everyone should include these commands on their pages
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenRecipesCommand { get; set; }
        public ICommand OpenDiaryCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }


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

           
            OpenHealthPlanCommand = new MvxCommand(() =>
            {
                ShowViewModel<HealthPlanViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenDiaryCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenHomeCommand = new MvxCommand(() =>
            {
                ShowViewModel<GraphViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenRecipesCommand = new MvxCommand(() =>
            {
                ShowViewModel<RecipeViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenExerciseCommand = new MvxCommand(() =>
            {
                ShowViewModel<CreateNewGViewModel>(new { userid = UserId });
                Close(this);
            });
            //OpenCommunityCommand = new MvxCommand(() =>
            //{
            //    ShowViewModel<CommunityViewModel>();
            //    Close(this);
            //});

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