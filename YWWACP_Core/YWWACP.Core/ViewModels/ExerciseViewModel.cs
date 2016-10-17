using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Java.Lang;
using YWWACP.Core.Database;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class ExerciseViewModel : MvxViewModel
    {

        private readonly IDatabase database;
        public ICommand RecipesViewCommand { get; set; }
        public ICommand SelectExerciseCommand { get; set; }

        private ObservableCollection<NewExerciseThread> newExercise = new ObservableCollection<NewExerciseThread>();

        public ObservableCollection<NewExerciseThread> NewExercise
        {
            get { return newExercise; }
            set { SetProperty(ref newExercise, value); }
        }

        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }


        public ExerciseViewModel(IDatabase database)
        {
            this.database = database;
            /*AddNewThreadCommand = new MvxCommand(() => ShowViewModel<CreateNewThreadViewModel>(new { userid = UserId }));*/
            SelectExerciseCommand = new MvxCommand<NewExerciseThread>(thread => ShowViewModel<SingleExerciseViewModel>(new { exerciseId = thread.ExerciseId }));

            
            RecipesViewCommand = new MvxCommand(() =>
            {
                ShowViewModel<RecipeViewModel>(new { userid = UserId });
                Close(this);
            });
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public void OnResume()
        {
            GetExercises();
        }

        public async void GetExercises()
        {
            var threads = await database.GetTable();
            NewExercise.Clear();
            foreach (var thread in threads)
            {
                var c = thread.ExerciseId;

                if (c != null)
                {
                    NewExercise.Insert(0, new NewExerciseThread(thread.ExerciseId, thread.ExerciseTitle, thread.ExerciseSummary));
                }
            }

            RaisePropertyChanged(() => NewExercise);

        }

    }

}
