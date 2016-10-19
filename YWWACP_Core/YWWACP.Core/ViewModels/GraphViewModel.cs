using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.ViewModels
{
    public class GraphViewModel : MvxViewModel
    {
        // Everyone should include these commands on their pages
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenRecipesCommand { get; set; }
        public ICommand OpenDiaryCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }

        private readonly IDatabase database;

        public ICommand GraphShow { get; set; }


        private string userId;
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }
        private string connection;

        public string Connection
        {
            get { return connection; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref connection, value);
                }

            }
        }
        public GraphViewModel()
        {
            //  this.database = database;
            //    AddNewThreadCommand = new MvxCommand(() => ShowViewModel<CreateNewThreadViewModel>(new { userid = UserId }));
            //    SelectThreadCommand = new MvxCommand<NewDiscussionThread>(thread => ShowViewModel<CommentsViewModel>(new { threadID = thread.ThreadID }));
            //    GraphShow = new MvxCommand(() =>
            //       {
            //          ShowViewModel<GraphViewModel>(new { userid = UserId });
            //            Close(this);
            //         });



            // THESE COMMANDS MUST EVERYONE IMPLEMENT IN THEIR CONSTRUCTORS.
            // I HAVE NOT COMMENTED OUT DIARY BECAUSE THAT DOES NOT EXIST AT THIS POINT.
            // COMMUNITY IS COMMENTED OUT BECAUSE THIS IS THE COMMUNITY VIEW AND IT MAKES ABSOULTE NO SENS TO NAVIGATE TO THE VIEW THAT YOU ARE IN
            // MAKE SURE YOU DO THE SAME
            OpenHealthPlanCommand = new MvxCommand(() =>
            {
                ShowViewModel<HealthPlanViewModel>(new { userid = UserId });
                Close(this);
            });
            //OpenDiaryCommand = new MvxCommand(() =>
            //{
            //    ShowViewModel<DiaryViewModel>(new {userid = UserId});
            //    Close(this);
            //});
            OpenHomeCommand = new MvxCommand(() =>
            {
                ShowViewModel<FirstViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenRecipesCommand = new MvxCommand(() =>
            {
                ShowViewModel<RecipeViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenExerciseCommand = new MvxCommand(() =>
            {
                ShowViewModel<ExerciseViewModel>(new { userid = UserId });
                Close(this);
            });
            //OpenCommunityCommand = new MvxCommand(() =>
            //{
            //    ShowViewModel<CommunityViewModel>();
            //    Close(this);
            //});

        }


    }
}
