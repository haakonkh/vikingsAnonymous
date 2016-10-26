using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Java.Sql;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    public class ExerciseDetailsViewModel: MvxViewModel
    {
        public IDatabase database;
        public ICommand AddToPlanCommand { get; set; }
        public ICommand NextDayCommand { get; set; }
        public ICommand PrevDayCommand { get; set; }
        public ICommand TodayCommand { get; set; }
        //Exercise properties
        private string exerciseID;

        public string ExerciseID
        {
            get { return exerciseID; }
            set { SetProperty(ref exerciseID, value); }
        }
        private string exerciseContent;

        public string ExerciseContent
        {
            get { return exerciseContent; }
            set { SetProperty(ref exerciseContent, value); }
        }
        private string exerciseTitle;

        public string ExerciseTitle
        {
            get { return exerciseTitle; }
            set { SetProperty(ref exerciseTitle, value); }
        }
        private string displayExerciseSets;

        public string DisplayExerciseSets
        {
            get { return displayExerciseSets; }
            set { SetProperty(ref displayExerciseSets, value); }
        }
        private string displayExerciseReps;

        public string DisplayExerciseReps
        {
            get { return displayExerciseReps; }
            set { SetProperty(ref displayExerciseReps, value); }
        }

        private int exerciseSets;

        public int ExerciseSets
        {
            get { return exerciseSets; }
            set { SetProperty(ref exerciseSets, value); }
        }
        private int exerciseReps;

        public int ExerciseReps
        {
            get { return exerciseReps; }
            set { SetProperty(ref exerciseReps, value); }
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        private DateTime exerciseDate;
        public DateTime ExerciseDate
        {
            get { return exerciseDate; }
            set
            {
                if (value != exerciseDate)
                {
                    exerciseDate = value;
                    RaisePropertyChanged(() => ExerciseDate);
                    if (ExerciseDate.Date == DateTime.Now.Date)
                    {
                        ShowDate = "Today";
                    }
                    else
                    {
                        ShowDate = ExerciseDate.ToString("dd/MM/yyyy");

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
        public ExerciseDetailsViewModel(IDatabase database)
        {
            this.database = database;
            NextDayCommand = new MvxCommand(() =>
            {
                ExerciseDate = ExerciseDate.AddDays(1);
                RaisePropertyChanged(() => ExerciseDate);
            });
            PrevDayCommand = new MvxCommand(() =>
            {
                if (ExerciseDate.Date > DateTime.Now.Date)
                {
                    ExerciseDate = ExerciseDate.AddDays(-1);
                    RaisePropertyChanged(() => ExerciseDate);
                }
                else
                {
                    Mvx.Resolve<IToast>().Show("You cannot plan backwards in time");
                }

            });
            TodayCommand = new MvxCommand(() =>
            {
                ShowViewModel<ExercisePickDay>(new { exerciseId = ExerciseID, userId = UserId, currentDate = ExerciseDate });
                Close(this);
            });
            AddToPlanCommand = new MvxCommand(() =>
            {
                addToTable();
                Close(this);
                Mvx.Resolve<IToast>().Show(ExerciseTitle+" added to plan!");
            });

        }

        public async void addToTable()
        {
            await database.InsertTableRow(new MyTable() { ExerciseSummary = ExerciseContent, ExerciseTitle = ExerciseTitle, Sets = ExerciseSets, Reps = ExerciseReps, ExerciseTimestamp = ExerciseDate.ToString("dd/MM/yyyy"), ExerciseDate=ExerciseDate.ToString(), UserId = UserId, ExerciseId = GenerateExerciseID() });

        }

        public void Init(string exerciseID,string userId, DateTime DateIn)
        {
            ExerciseID = exerciseID;
            UserId = userId;
            if (DateIn == DateTime.MinValue)
            {
                ExerciseDate = DateTime.Now.Date;

            }
            else
            {
                ExerciseDate = DateIn;
            }
        }

        public void OnResume()
        {
            GetExercise();
        }

        public string GenerateExerciseID()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "").Replace("+", "");

            string GS = Convert.ToBase64String(g.ToByteArray());
            GS = GuidString.Replace("=", "").Replace("+", "");
            return GuidString + GS;
        }

        private async void GetExercise()
        {
            var exercises = await database.GetTable();
            foreach (var exercise in exercises)
            {
                if (ExerciseID == exercise.ExerciseId)
                {
                    ExerciseContent = exercise.ExerciseSummary;
                    ExerciseTitle = exercise.ExerciseTitle;
                    ExerciseSets = exercise.Sets;
                    ExerciseReps = exercise.Reps;
                    if(exercise.Reps > 0) {
                    DisplayExerciseReps = "Reps: " + exercise.Reps;
                    }
                    if (exercise.Sets > 0)
                    {
                        DisplayExerciseSets = "Sets: " + exercise.Sets;
                    }
                    
                    RaiseAllPropertiesChanged();
                    break;
                }
                
            }
        }
    }
}
