using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Java.Lang;
using YWWACP.Core.Database;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Diary;

namespace YWWACP.Core.ViewModels
{
    public class RecipeViewModel : MvxViewModel
    {
        //navbar
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenDiaryCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }

        private readonly IDatabase database;
        public ICommand ExerciseViewCommand { get; set; }
        public ICommand SelectRecipeCommand { get; set; }
        public ICommand CreateNewRecipeCommand { get; set; }

        private ObservableCollection<NewRecipeThread> newRecipes = new ObservableCollection<NewRecipeThread>();

        public ObservableCollection<NewRecipeThread> NewRecipes
        {
            get { return newRecipes; }
            set { SetProperty(ref newRecipes, value); }
        }

        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }


        public RecipeViewModel(IDatabase database)
        {
            this.database = database;
            CreateNewRecipeCommand = new MvxCommand(() => ShowViewModel<CreateNewRecipeViewModel>(new { userid = UserId }));
            SelectRecipeCommand = new MvxCommand<NewRecipeThread>(thread => ShowViewModel<SingleRecipeViewModel>(new { mealid = thread.MealId }));


            ExerciseViewCommand = new MvxCommand(() =>
            {
                ShowViewModel<ListExercisesViewModel>(new { userid = UserId });
                Close(this);
            });

            // Navbar
            OpenHealthPlanCommand = new MvxCommand(() =>
            {
                ShowViewModel<HealthPlanViewModel>(new { userId = UserId });
                Close(this);
            });
            OpenDiaryCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryViewModel>(new { userId = UserId});
                Close(this);
            });
            OpenHomeCommand = new MvxCommand(() =>
            {
                ShowViewModel<FirstViewModel>(new { userid = UserId });
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

        public void Init(string userid)
        {
            UserId = userid;
        }

        public void OnResume()
        {
            GetRecipes();
        }

        public async void GetRecipes()
        {
            var threads = await database.GetTable();
            NewRecipes.Clear();
            foreach (var thread in threads)
            {
                var c = thread.MealId;

                if (c != null && thread.basic)
                {
                    NewRecipes.Insert(0, new NewRecipeThread(thread.MealId, thread.MealTitle, thread.MealSummary));
                }
            }

            RaisePropertyChanged(() => NewRecipes);

        }

    }

}