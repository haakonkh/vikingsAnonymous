using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Core.ViewModels
{
    //Author: Student 9792538, Eirik Baug
    public class ViewExerciseDetailsViewModel:MvxViewModel
    {
        public IDatabase database;

        public ViewExerciseDetailsViewModel(IDatabase database)
        {
            this.database = database;


        }
        public void Init(string exerciseId, string userid)
        {
            ExerciseID = exerciseId;
            UserId = userid;
           
        }
        private string exerciseID;

        public string ExerciseID
        {
            get { return exerciseID; }
            set { SetProperty(ref exerciseID, value); }
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
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
                    ExerciseContent = exercise.ExerciseSummary;
                    ExerciseTitle = exercise.ExerciseTitle;
                    ExerciseSets = exercise.Sets;
                    ExerciseReps = exercise.Reps;
                    ShowDate = exercise.ExerciseTimestamp;
                    RaiseAllPropertiesChanged();
                    break;
                }

            }
        }
    }
}
