using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Java.Sql;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    public class ExerciseDetailsViewModel: MvxViewModel
    {
        public IDatabase database;

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
        }

        public void Init(string exerciseID)
        {
            ExerciseID = exerciseID;
            
        }

        public void OnResume()
        {
            GetExercise();
        }

        private async void GetExercise()
        {
            var exercises = await database.GetTable();
            foreach (var exercise in exercises)
            {
                if (ExerciseID == exercise.ExerciseId)
                {
                    ExerciseContent = exercise.ExerciseContent;
                    ExerciseTitle = exercise.ExerciseTittle;
                    ExerciseSets = exercise.Sets;
                    ExerciseReps = exercise.Reps;
                    RaisePropertyChanged(() => ExerciseContent);
                    RaisePropertyChanged(() => ExerciseTitle);
                    RaisePropertyChanged(() => ExerciseSets);
                    RaisePropertyChanged(() => ExerciseReps);
                    break;
                }
                
            }
        }
    }
}
