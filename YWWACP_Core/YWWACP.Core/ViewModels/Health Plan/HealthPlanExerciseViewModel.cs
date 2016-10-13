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
        public ICommand AddExerciseCommand { get; set; }

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
            AddExerciseCommand = new MvxCommand(() => ShowViewModel<AddExerciseViewModel>(new { userid = UserId }));


        }


        async void testStart()
        {
            DeleteEverything();
            await database.InsertTableRow(new MyTable() { ExerciseContent = "Run bitch, run!", ExerciseTittle = "Running", Sets = 0, Reps = 0, ExerciseTimestamp = new DateTime(2016, 10, 12, 15, 30, 0).ToString(), UserId = UserId });
            await database.InsertTableRow(new MyTable() { ExerciseContent = "Bounce up and down", ExerciseTittle = "Squatting", Sets = 4, Reps = 8, ExerciseTimestamp = new DateTime(2016, 10, 15, 12, 45, 0).ToString(),UserId = UserId});
            await database.InsertTableRow(new MyTable() { ExerciseContent = "Kick a ball", ExerciseTittle = "Football", Sets = 0, Reps = 0, ExerciseTimestamp = new DateTime(2016, 10, 15, 13, 45, 0).ToString(), UserId = "sdfgsdfgsdfg" });
            GetExercises();
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

                if (exercise.ExerciseContent != null && exercise.UserId == UserId)
                {
                    Exercises.Insert(0, new Exercise(exercise.ExerciseTittle, exercise.ExerciseContent, exercise.Sets, exercise.Reps,exercise.ExerciseTimestamp));
                }
            }

            RaisePropertyChanged(() => Exercises);

        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

    }
}
