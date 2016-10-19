using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Java.Sql;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    public class ExerciseDetailsViewModel: MvxViewModel
    {
        public IDatabase database;
        public ICommand AddToPlanCommand { get; set; }

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
        /*
        private DateTime exerciseTime;
        public DateTime ExerciseTime
        {
            get { return exerciseTime; }
            set
            {
                if (value != null && value != exerciseTime)
                {
                    exerciseTime = value;
                    RaisePropertyChanged(() => ExerciseTime);
                }
            }
        }*/
        private DateTime exerciseDate;
        public DateTime ExerciseDate
        {
            get { return exerciseDate; }
            set
            {
                if (value != null && value != exerciseDate)
                {
                    exerciseDate = value;
                    RaisePropertyChanged(() => ExerciseDate);
                }
            }
        }
        public ExerciseDetailsViewModel(IDatabase database)
        {
            this.database = database;

            AddToPlanCommand = new MvxCommand(() =>
            {
                addToTable();
                Close(this);
            });

        }

        public async void addToTable()
        {
            await database.InsertTableRow(new MyTable() { ExerciseSummary = ExerciseContent, ExerciseTitle = ExerciseTitle, Sets = ExerciseSets, Reps = ExerciseReps, ExerciseTimestamp = ExerciseDate.ToString("dd/MM/yyyy"), ExerciseDate=ExerciseDate.ToString(), UserId = UserId, ExerciseId = GenerateExerciseID() });

        }

        public void Init(string exerciseID,string userId)
        {
            ExerciseID = exerciseID;
            UserId = userId;
            ExerciseDate = DateTime.Now.Date;
            RaisePropertyChanged(() => ExerciseDate);
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
                    
                    RaisePropertyChanged(() => ExerciseContent);
                    RaisePropertyChanged(() => ExerciseTitle);
                    RaisePropertyChanged(() => ExerciseSets);
                    RaisePropertyChanged(() => ExerciseReps);
                    RaisePropertyChanged(() => DisplayExerciseReps);
                    RaisePropertyChanged(() => DisplayExerciseSets);
                    break;
                }
                
            }
        }
    }
}
