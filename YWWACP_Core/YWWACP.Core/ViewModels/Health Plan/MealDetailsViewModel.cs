using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    public class MealDetailsViewModel: MvxViewModel
    {
        public IDatabase database;
        public ICommand AddToPlanCommand { get; set; }
        public MealDetailsViewModel(IDatabase database)
        {
            this.database = database;
            AddToPlanCommand = new MvxCommand(() =>
            {
                addToTable();
                Close(this);
            });

        }
        private DateTime mealDate;
        public DateTime MealDate
        {
            get { return mealDate; }
            set
            {
                if (value != null && value != mealDate)
                {
                    mealDate = value;
                    RaisePropertyChanged(() => MealDate);
                }
            }
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }
        public async void addToTable()
        {
            await database.InsertTableRow(new MyTable() { MealSummary = MealContent, MealTitle = MealTitle,  MealTimestamp = MealDate.ToString("dd/MM/yyyy"), ExerciseDate = MealDate.ToString(), UserId = UserId, ExerciseId = GenerateMealID() });

        }

        public void Init(string mealId, string userId)
        {
            MealID = mealId;
            GetMeal();
            UserId = userId;
            MealDate = DateTime.Now.Date;
            RaisePropertyChanged(() => MealDate);
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
        private string mealTitle;

        public string MealTitle
        {
            get { return mealTitle; }
            set { SetProperty(ref mealTitle, value); }
        }
        public void OnResume()
        {
            GetMeal();
        }

        public string GenerateMealID()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "").Replace("+", "");

            string GS = Convert.ToBase64String(g.ToByteArray());
            GS = GuidString.Replace("=", "").Replace("+", "");
            return GuidString + GS;
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
                    
                    RaisePropertyChanged(() => MealContent);
                    RaisePropertyChanged(() => MealTitle);
                   
                    break;
                }

            }
        }
    }
}
