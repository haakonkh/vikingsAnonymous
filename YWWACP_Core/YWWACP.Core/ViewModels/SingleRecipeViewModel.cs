using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class SingleRecipeViewModel : MvxViewModel
    {
        private readonly IDatabase database;
        private ObservableCollection<Meal> meals = new ObservableCollection<Meal>();

        private string _mealId;

        public string MealID
        {
            get { return _mealId; }
            set
            {
                _mealId = value;
                RaisePropertyChanged(() => MealID);
            }
        }

        private string _mealTitle;

        public string MealTitle
        {
            get { return _mealTitle; }
            set { SetProperty(ref _mealTitle, value); }
        }

        private string _mealSummary;

        public string MealSummary
        {
            get { return _mealSummary; }
            set { SetProperty(ref _mealSummary, value); }
        }


        public ObservableCollection<Meal> Meals
        {
            get { return meals; }
            set { SetProperty(ref meals, value); }
        }

        /* public ICommand AddCommentCommand { get; set; }*/

        public SingleRecipeViewModel(IDatabase database)
        {
            this.database = database;
            
        }

        public void Init(string mealid)
        {
            MealID = mealid;
        }

        public void OnResume()
        {
            GetRecipes();
        }

        public async void GetRecipes()
        {
            SetThreadContentOnRecipes();
            var loadRecipes = await database.GetTable();
            Meals.Clear();

            foreach (var recipe in loadRecipes)
            {
                if (recipe.MealId != null)
                {
                    if (MealID == recipe.MealId)
                    {
                        Meals.Add(new Meal(recipe.MealId,recipe.MealTitle,recipe.MealSummary,recipe.Ingredients,recipe.Approach));
                    }
                }
            }
            RaisePropertyChanged(() => Meals);
        }

        /// <summary>
        /// Sets thread content on top of the screen
        /// Gets called innside GetComments
        /// </summary>
        private async void SetThreadContentOnRecipes()
        {
            var loadThreads = await database.GetTable();
            foreach (var threads in loadThreads)
            {
                if (MealID == threads.MealId)
                {
                    MealTitle = threads.MealTitle;
                    break;
                }
                RaisePropertyChanged(() => MealTitle);
            }
        }
    }
}
