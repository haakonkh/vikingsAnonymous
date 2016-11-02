using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Core.ViewModels
{
    //Author: Student 9792538, Eirik Baug
    public class ViewMealDetailsViewModel:MvxViewModel
    {
        public IDatabase database;

        public ViewMealDetailsViewModel(IDatabase database)
        {
            this.database = database;
            

        }
        public void Init(string mealId, string userid)
        {
            MealID = mealId;
            UserId = userid;

        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        private string mealID;

        public string MealID
        {
            get { return mealID; }
            set { SetProperty(ref mealID, value); }
        }
        private string mealContent;

        public string MealContent
        {
            get { return mealContent; }
            set { SetProperty(ref mealContent, value); }
        }
        private string mealIngredients;

        public string MealIngredients
        {
            get { return mealIngredients; }
            set { SetProperty(ref mealIngredients, value); }
        }
        private string mealApproach;

        public string MealApproach
        {
            get { return mealApproach; }
            set { SetProperty(ref mealApproach, value); }
        }
        private string mealTitle;

        public string MealTitle
        {
            get { return mealTitle; }
            set { SetProperty(ref mealTitle, value); }
        }
        private string mealType;

        public string MealType
        {
            get { return mealType; }
            set { SetProperty(ref mealType, value); }
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
            GetMeal();
        }

        private async void GetMeal()
        {
            var meals = await database.GetTable();
            foreach (var meal in meals)
            {
                if (MealID == meal.MealId)
                {

                    MealContent = meal.MealSummary;
                    MealTitle = meal.MealTitle;
                    MealApproach = meal.Approach;
                    MealIngredients = meal.Ingredients;
                    ShowDate = meal.MealTimestamp;
                    MealType = meal.MealType;
                    RaiseAllPropertiesChanged();

                    break;
                }

            }
        }
    }
}
