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
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Diary;
using YWWACP.Core.ViewModels.Goal;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Core.ViewModels
{
    //Author: Student 9792538, Eirik Baug
    public class HealthPlanViewModel : MvxViewModel
    {
        //Navigation
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenRecipesCommand { get; set; }
        public ICommand OpenDiaryCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }

        public ICommand SelectEntryCommand { get; set; }
        public ICommand OpenHealthPlanExerciseCommand { get; set; }
        public ICommand OpenMealCommand { get; set; }

        public IDatabase database;

        private ObservableCollection<DiaryEntry> entries = new ObservableCollection<DiaryEntry>();
        public ObservableCollection<DiaryEntry> Entries
        {
            get { return entries; }
            set
            {
                SetProperty(ref entries, value);

            }

        }
        public HealthPlanViewModel(IDatabase database)
        {
            this.database = database;

            OpenHealthPlanExerciseCommand = new MvxCommand(() => ShowViewModel<HealthPlanExerciseViewModel>(new { userid = UserId }));
            OpenMealCommand = new MvxCommand(() => ShowViewModel<HealthPlanMealViewModel>(new { userid = UserId}));
            SelectEntryCommand = new MvxCommand<DiaryEntry>(entry =>
            {
                if (entry.Exercise != null)
                {
                    ShowViewModel<ViewExerciseDetailsViewModel>(new { exerciseId = entry.Exercise.ExerciseID, userid = UserId });
                }
                else if (entry.Meal != null)
                {
                    ShowViewModel<ViewMealDetailsViewModel>(new { mealId = entry.Meal.MealId, userid = UserId});
                }
              
               
            });

            //Navigation
            OpenDiaryCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryViewModel>(new { userid = UserId});
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
            OpenCommunityCommand = new MvxCommand(() =>
            {
                ShowViewModel<CommunityViewModel>(new { userid = UserId});
                Close(this);
            });
        }
        public void Init( string userid)
        {
            UserId = userid;
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }
        public void OnResume()
        {
            GetTodaysPlan();
        }
        private async void GetTodaysPlan()
        {
            var entriesDb = await database.GetTable();
            Entries.Clear();
            foreach (var entry in entriesDb)
            {

                if ((entry.ExerciseTimestamp != null || entry.MealTimestamp != null) && entry.UserId == UserId)
                {
                    var dt = new DateTime();
                    var exercise = new Exercise();
                    var meal = new Meal();
                    var type = "";
                    var title = "";
                    if (entry.ExerciseTimestamp != null)
                    {
                        dt = Convert.ToDateTime(entry.ExerciseDate);
                        exercise = new Exercise(entry.ExerciseTitle, entry.ExerciseSummary, entry.Sets, entry.Reps, entry.ExerciseTimestamp, entry.ExerciseId);
                        type = "Exercise";
                        title = entry.ExerciseTitle;
                    }
                    else
                    {
                        dt = Convert.ToDateTime(entry.MealTimestamp);
                        meal = new Meal(entry.MealId, entry.MealTitle, entry.MealSummary, entry.Ingredients, entry.Approach, entry.MealTimestamp,entry.MealType);
                        type = "Meal - " +entry.MealType.ToLower();
                        title = entry.MealTitle;
                    }
                    if (dt.Date == DateTime.Now.Date && type == "Exercise")
                    {
                        Entries.Add(new DiaryEntry(null, exercise, type, title));
                    }
                    else if(dt.Date == DateTime.Now.Date)
                    {
                        Entries.Insert(0,new DiaryEntry(meal, null, type, title));

                    }
                }

            }
            RaisePropertyChanged(() => Entries);
            if (Entries.Count == 0)
            {
                Entries.Insert(0, new DiaryEntry(null,null,"","Nothing planned today"));
                RaisePropertyChanged(() => Entries);
            }

        }
    }
}
