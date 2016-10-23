using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Diary;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Core.ViewModels
{
    public class HealthPlanViewModel : MvxViewModel
    {
        //Navigation
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenRecipesCommand { get; set; }
        public ICommand OpenDiaryCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }

        public ICommand OpenHealthPlanExerciseCommand { get; set; }
        public ICommand OpenMealCommand { get; set; }

        public IDatabase database;

        public HealthPlanViewModel(IDatabase database)
        {
            this.database = database;

            OpenHealthPlanExerciseCommand = new MvxCommand(() => ShowViewModel<HealthPlanExerciseViewModel>(new { userid = UserId }));
            OpenMealCommand = new MvxCommand(() => ShowViewModel<HealthPlanMealViewModel>());

            //Navigation
            OpenDiaryCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryViewModel>(new {userid = UserId});
                Close(this);
            });
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
                ShowViewModel<CreateNewGViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenCommunityCommand = new MvxCommand(() =>
            {
                ShowViewModel<CommunityViewModel>();
                Close(this);
            });
        }
        public void Init( string userId)
        {
            UserId = userId;
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

    }
}
