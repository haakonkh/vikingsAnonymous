using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YWWACP.Core.Database;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
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


            // THESE COMMANDS MUST EVERYONE IMPLEMENT IN THEIR CONSTRUCTORS.
            // I HAVE NOT COMMENTED OUT DIARY BECAUSE THAT DOES NOT EXIST AT THIS POINT.
            // COMMUNITY IS COMMENTED OUT BECAUSE THIS IS THE COMMUNITY VIEW AND IT MAKES ABSOULTE NO SENS TO NAVIGATE TO THE VIEW THAT YOU ARE IN
            // MAKE SURE YOU DO THE SAME
            OpenHealthPlanCommand = new MvxCommand(() =>
            {
                ShowViewModel<HealthPlanViewModel>(new {userid = UserId});
                Close(this);
            });
            //OpenDiaryCommand = new MvxCommand(() =>
            //{
            //    ShowViewModel<DiaryViewModel>(new {userid = UserId});
            //    Close(this);
            //});
            OpenHomeCommand = new MvxCommand(() =>
            {
                ShowViewModel<FirstViewModel>(new {userid = UserId});
                Close(this);
            });
            OpenRecipesCommand = new MvxCommand(() =>
            {
                ShowViewModel<RecipeViewModel>(new {userid = UserId});
                Close(this);
            });
            OpenExerciseCommand = new MvxCommand(() =>
            {
                ShowViewModel<ExerciseViewModel>(new {userid = UserId});
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
