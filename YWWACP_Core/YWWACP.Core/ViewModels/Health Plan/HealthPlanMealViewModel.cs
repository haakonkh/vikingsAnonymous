﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    //Author: Student 9792538, Eirik Baug
    public class HealthPlanMealViewModel: MvxViewModel
    {
        public IDatabase database;

        private ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        
        public ICommand OpenNewMealCommand { get; set; }
        public ICommand SelectMealCommand { get; set; }


        public ObservableCollection<Meal> Meals
        {
            get { return meals; }
            set
            {
                SetProperty(ref meals, value);

            }

        }

        public HealthPlanMealViewModel(IDatabase database)
        {
            this.database = database;
            OpenNewMealCommand = new MvxCommand(() => ShowViewModel<AddMealViewModel>(new { userid = UserId }));

            SelectMealCommand = new MvxCommand<Meal>(meal =>
            {
                    if(meal.MealId != null) {
                    ShowViewModel<ViewMealDetailsViewModel>(new { mealId = meal.MealId, userid = UserId });
                }

            });
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public void OnResume()
        {
            GetMeals();
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public async void GetMeals()
        {
            var meals = await database.GetTable();
            Meals.Clear();
            foreach (var meal in meals)
            {

                if (meal.MealTimestamp != null && meal.UserId == UserId && Convert.ToDateTime(meal.MealTimestamp).Date >= DateTime.Now.Date)
                {
                    Meals.Insert(0, new Meal(meal.MealId, meal.MealTitle, meal.MealSummary, meal.Ingredients, meal.Approach, meal.MealTimestamp,meal.MealType));
                }
            }
            RaisePropertyChanged(() => Meals);
            if (Meals.Count == 0)
            {
                Meals.Insert(0, new Meal(null,"No meals planned", null, null, null, null,null));
                RaisePropertyChanged(() => Meals);
            }
        }
    }
}
