using System.Collections.ObjectModel;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

//Author: Student n9808205, Student Ingrid Skar

namespace YWWACP.Core.ViewModels.ExerciseRecipe
{
    public class CreateNewGViewModel : MvxViewModel
    {

        private readonly IDatabase database;
        /*public ICommand AddNewThreadCommand { get; set; }
        public ICommand MyThreadsCommand { get; set; }*/
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


        public CreateNewGViewModel(IDatabase database)
        {
            this.database = database;
            /*AddNewThreadCommand = new MvxCommand(() => ShowViewModel<CreateNewThreadViewModel>(new { userid = UserId }));*/
            SelectExerciseCommand = new MvxCommand<NewExerciseThread>(thread => ShowViewModel<SingleExerciseViewModel>(new { exerciseId = thread.ExerciseId }));

            /*
            MyThreadsCommand = new MvxCommand(() =>
            {
                ShowViewModel<MyThreadsViewModel>(new { userid = UserId });
                Close(this);
            });*/
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

                if (c != null && thread.basic)
                {
                    NewExercise.Insert(0, new NewExerciseThread(thread.ExerciseId, thread.ExerciseTitle, thread.ExerciseSummary));
                }
            }

            RaisePropertyChanged(() => NewExercise);

        }

    }

}
