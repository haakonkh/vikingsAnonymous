using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    public class AddExerciseViewModel: MvxViewModel
    {
        private ObservableCollection<Exercise> exercises = new ObservableCollection<Exercise>();

        public ObservableCollection<Exercise> Exercises
        {
            get { return exercises; }
            set
            {
                SetProperty(ref exercises, value);

            }

        }
        public ICommand SelectExerciseCommand { get; set; }

        public IDatabase database;

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }
        public AddExerciseViewModel(IDatabase database)
        {
            this.database = database;
            GetExercises();
            SelectExerciseCommand = new MvxCommand<Exercise>(exercise => ShowViewModel<ExerciseDetailsViewModel>(new { exerciseID = exercise.ExerciseID, userId = UserId }));
        }
        public void Init(string userId)
        {
            UserId = userId;

        }
        public void OnResume()
        {
            GetExercises();
        }
        public async void GetExercises()
        {
            var exercises = await database.GetTable();
            Exercises.Clear();
            foreach (var exercise in exercises)
            {

                if (exercise.ExerciseContent != null && exercise.basic)
                {
                    Exercises.Insert(0, new Exercise(exercise.ExerciseTitle, exercise.ExerciseContent, exercise.Sets, exercise.Reps, exercise.ExerciseTimestamp,exercise.ExerciseId));

                }
            }

            RaisePropertyChanged(() => Exercises);

        }
    }
}
