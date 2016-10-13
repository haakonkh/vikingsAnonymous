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
    public class RecipeViewModel : MvxViewModel
    {

        private readonly IDatabase database;
        /*public ICommand AddNewThreadCommand { get; set; }
        public ICommand MyThreadsCommand { get; set; }*/
        public ICommand SelectRecipeCommand { get; set; }

       private ObservableCollection<NewRecipeThread> newRecipes = new ObservableCollection<NewRecipeThread>();

        public ObservableCollection<NewRecipeThread> NewRecipes
        {
            get { return newRecipes; }
            set { SetProperty(ref newRecipes, value); }
        } 

        private string _userId;

        public string UserId
        {
            get { return _userId; }
            set { SetProperty(ref _userId, value); }
        }


        public RecipeViewModel(IDatabase database)
        {
            this.database = database;
            /*AddNewThreadCommand = new MvxCommand(() => ShowViewModel<CreateNewThreadViewModel>(new { userid = UserId }));*/
            SelectRecipeCommand = new MvxCommand<NewRecipeThread>(thread => ShowViewModel<SingleRecipeViewModel>(new { mealid = thread.MealId }));

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
            GetRecipes();
        }

        public async void GetRecipes()
        {
            var threads = await database.GetTable();
            NewRecipes.Clear();
            foreach (var thread in threads)
            {
                var c = thread.MealId;

                if (c != null)
                {
                    NewRecipes.Insert(0, new NewRecipeThread(thread.MealId, thread.MealTitle, thread.MealSummary));
                }
            }

            RaisePropertyChanged(() => NewRecipes);

        }

    }

}
