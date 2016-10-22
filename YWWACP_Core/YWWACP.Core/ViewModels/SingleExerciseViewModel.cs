using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.Graphics;
using Android.Graphics.Drawables;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class SingleExerciseViewModel : MvxViewModel
    {
        private readonly IDatabase database;
        private ObservableCollection<Exercise> exercise = new ObservableCollection<Exercise>();

        private string _exerciseId;

        public string ExerciseId
        {
            get { return _exerciseId; }
            set
            {
                _exerciseId = value;
                RaisePropertyChanged(() => ExerciseId);
            }
        }

        private string _exerciseTitle;

        public string ExerciseTitle
        {
            get { return _exerciseTitle; }
            set { SetProperty(ref _exerciseTitle, value); }
        }

        

        public ObservableCollection<Exercise> Exercises
        {
            get { return exercise; }
            set { SetProperty(ref exercise, value); }
        }

        /* public ICommand AddCommentCommand { get; set; }*/

        public SingleExerciseViewModel(IDatabase database)
        {
            this.database = database;

        }

        public void Init(string exerciseId)
        {
            ExerciseId = exerciseId;
        }

        public void OnResume()
        {
            GetExercises();
        }

        public async void GetExercises()
        {
            SetThreadContentOnExercise();
            var loadExercises = await database.GetTable();
            Exercises.Clear();

            foreach (var e in loadExercises)
            {
                if (e.ExerciseId != null)
                {
                    if (ExerciseId == e.ExerciseId)
                    {
                        Exercises.Add(new Exercise(e.ExerciseId,e.ExerciseTitle,e.ExerciseSummary,e.Sets,e.Reps));
                    }
                }
            }
            RaisePropertyChanged(() => Exercises);
        }

        

        /// <summary>
        /// Sets thread content on top of the screen
        /// Gets called innside GetComments
        /// </summary>
        private async void SetThreadContentOnExercise()
        {
            var loadThreads = await database.GetTable();
            foreach (var threads in loadThreads)
            {
                if (ExerciseId == threads.ExerciseId)
                {
                    ExerciseTitle = threads.ExerciseTitle;
                    break;
                }
                RaisePropertyChanged(() => ExerciseTitle);
            }
        }
    }
}
