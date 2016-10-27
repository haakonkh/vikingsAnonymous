using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.Content;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    public class HealthPlanExerciseViewModel: MvxViewModel
    {
        public IDatabase database;

        private ObservableCollection<Exercise> exercises = new ObservableCollection<Exercise>();
        public ICommand OpenNewExerciseCommand { get; set; }
        public ICommand SelectExerciseCommand { get; set; }
        public ObservableCollection<Exercise> Exercises
        {
            get { return exercises; }
            set
            {
                SetProperty(ref exercises, value);

            }

        }

        public HealthPlanExerciseViewModel(IDatabase database)
        {
            this.database = database;
            testStart();
            OpenNewExerciseCommand = new MvxCommand(() => ShowViewModel<AddExerciseViewModel>(new { userid = UserId }));
            SelectExerciseCommand = new MvxCommand<Exercise>(exercise =>
            {
                    if(exercise.ExerciseID != null) { 
                    ShowViewModel<ViewExerciseDetailsViewModel>(new { exerciseId = exercise.ExerciseID, userid = UserId });
                }

            });
        }


        async void testStart()
        {
            
            GetExercises();
        }
        public void Init(string userid)
        {
            UserId = userid;
        }

        public async void DeleteEverything()
        {
            var tables = await database.GetTable();
            foreach (var table in tables)
            {
                await database.DeleteTableRow(table.Id);
            }
        }

        public async void GetExercises()
        {
            var exercises = await database.GetTable();
            Exercises.Clear();
            foreach (var exercise in exercises)
            {

                if (exercise.ExerciseTimestamp != null && exercise.UserId == UserId && Convert.ToDateTime(exercise.ExerciseTimestamp).Date >= DateTime.Now.Date)
                {
                    Exercises.Insert(0, new Exercise(exercise.ExerciseTitle, exercise.ExerciseSummary, exercise.Sets, exercise.Reps,exercise.ExerciseTimestamp,exercise.ExerciseId));
                }
            }

            RaisePropertyChanged(() => Exercises);
            if (Exercises.Count == 0)
            {
                Exercises.Insert(0, new Exercise("No exercises planned", null, 0, 0, null, null));
                RaisePropertyChanged(() => Exercises);
            }
        }
        public void OnResume()
        {
            GetExercises();
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
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
    }
}
