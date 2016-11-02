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
using YWWACP.Core.ViewModels.Goal;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Core.ViewModels.Diary
{
    //Author: Student 9792538, Eirik Baug
    public class DiaryViewModel:MvxViewModel
    {
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenRecipesCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }

        public IDatabase database;
        public ICommand PrevDayCommand { get; set; }
        public ICommand TodayCommand { get; set; }
        public ICommand NextDayCommand { get; set; }
        public ICommand SelectEntryCommand { get; set; }

        private ObservableCollection<DiaryEntry> entries = new ObservableCollection<DiaryEntry>();
        public ObservableCollection<DiaryEntry> Entries
        {
            get { return entries; }
            set
            {
                SetProperty(ref entries, value);

            }

        }

        public DiaryViewModel(IDatabase database)
        {
            this.database = database;
            GetDiary();
            PrevDayCommand = new MvxCommand(() =>
            {
                Date = Date.AddDays(-1);
                RaisePropertyChanged(() => Date);
                
            });
            NextDayCommand = new MvxCommand(() =>
            {
                Date = Date.AddDays(1);
                RaisePropertyChanged(() => Date);
            });
            TodayCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryDayViewModel>(new { userid = UserId, currentDate = Date});
                Close(this);
            });

            SelectEntryCommand = new MvxCommand<DiaryEntry>(entry =>
            {
                if (entry.Exercise != null)
                {
                    ShowViewModel<ViewExerciseDetailsViewModel>(new { exerciseId = entry.Exercise.ExerciseID, userid = UserId });
                }
                else if(entry.Meal != null)
                {
                    ShowViewModel<ViewMealDetailsViewModel>(new { mealId = entry.Meal.MealId, userid = UserId });
                }


            });

            OpenHealthPlanCommand = new MvxCommand(() =>
            {
                ShowViewModel<HealthPlanViewModel>(new { userid = UserId });
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
        public void Init(string userid, DateTime DateIn)
        {
            UserId = userid;
            if (DateIn == DateTime.MinValue)
            {
                Date = DateTime.Now.Date;
            }
            else
            {
                Date = DateIn;
            }
            RaisePropertyChanged(() => Date);
        }
        public void OnResume()
        {
            GetDiary();
        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value != date)
                {
                    date = value;
                    GetDiary();
                    RaisePropertyChanged(() => Date);
                    if (Date.Date == DateTime.Now.Date)
                    {
                        ShowDate = "Today";
                    }
                    else
                    {
                        ShowDate = Date.ToString("dd/MM/yyyy");

                    }
                }
            }
        }
        private string showDate;
        public string ShowDate
        {
            get { return showDate; }
            set
            {
                if (value != showDate)
                {
                    showDate = value;
                    RaisePropertyChanged(() => ShowDate);

                }
            }
        }
        private string goalContent;
        public string GoalContent
        {
            get { return goalContent; }
            set
            {
                if (value != goalContent)
                {
                    goalContent = value;
                    RaisePropertyChanged(() => GoalContent);

                }
            }
        }
        private string goalSatisfaction;
        public string GoalSatisfaction
        {
            get { return goalSatisfaction; }
            set
            {
                if (value != goalSatisfaction)
                {
                    goalSatisfaction = value;
                    RaisePropertyChanged(() => GoalSatisfaction);

                }
            }
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        private async void GetDiary()
        {
            var entriesDb = await database.GetTable();
            Entries.Clear();
            GoalContent = "No goal for this day";
            GoalSatisfaction = "Not set";
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
                        meal = new Meal(entry.MealId, entry.MealTitle, entry.MealSummary, entry.Ingredients, entry.Approach, entry.MealTimestamp, entry.MealType);
                        type = "Meal - " + entry.MealType.ToLower();
                        title = entry.MealTitle;
                    }
                    if (dt.Date == Date.Date && type == "Exercise")
                    {
                        Entries.Add(new DiaryEntry(null, exercise, type, title));
                    }
                    else if (dt.Date == Date.Date)
                    {
                        Entries.Insert(0, new DiaryEntry(meal, null, type, title));

                    }
                }
                else if (entry.GoalId != null && Convert.ToDateTime(entry.GoalDate).Date == Date.Date)
                {
                    GoalContent = entry.GoalContent;
                    if (entry.GoalSatisfaction < 1.0)
                    {
                        GoalSatisfaction = "Not set";
                        
                    }
                    if (entry.GoalSatisfaction > 1.0 && entry.GoalSatisfaction <= 3.0)
                    {
                        GoalSatisfaction = "Bad";
                    }
                    if (entry.GoalSatisfaction > 3.0 && entry.GoalSatisfaction <= 6.0)
                    {
                        GoalSatisfaction = "Ok";
                    }
                    if (entry.GoalSatisfaction > 6 && entry.GoalSatisfaction <= 10.0)
                    {
                        GoalSatisfaction = "Great!";
                    }
                }
            }
            RaisePropertyChanged(() => Entries);
            if (Entries.Count == 0)
            {
                Entries.Insert(0, new DiaryEntry(null, null, "", "No entries for this day"));
                RaisePropertyChanged(() => Entries);
            }

        }

    }
}
