using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Diary;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    //Author: Student 9792538, Eirik Baug
    public class MealDetailsViewModel: MvxViewModel
    {
        public IDatabase database;
        public ICommand AddToPlanCommand { get; set; }
        public ICommand NextDayCommand { get; set; }
        public ICommand PrevDayCommand { get; set; }
        public ICommand TodayCommand { get; set; }
        public MealDetailsViewModel(IDatabase database)
        {
            this.database = database;
            NextDayCommand = new MvxCommand(() =>
            {
                MealDate = MealDate.AddDays(1);
                RaisePropertyChanged(() => MealDate);
            });
            PrevDayCommand = new MvxCommand(() =>
            {
                if (MealDate.Date > DateTime.Now.Date)
                {
                    MealDate = MealDate.AddDays(-1);
                    RaisePropertyChanged(() => MealDate);
                }
                else
                {
                    Mvx.Resolve<IToast>().Show("You cannot pick dates from the past");
                }

            });
            TodayCommand = new MvxCommand(() =>
            {
                ShowViewModel<MealPickDate>(new { mealId = MealID, userid = UserId, currentDate = MealDate,selectedItem = SelectedItem.Caption });
                Close(this);
            });
            AddToPlanCommand = new MvxCommand(() =>
            {
                addToTable();
                Close(this);
                Mvx.Resolve<IToast>().Show(MealTitle+" added to plan");
            });

        }
        private DateTime mealDate;
        public DateTime MealDate
        {
            get { return mealDate; }
            set
            {
                if (value != mealDate)
                {
                    mealDate = value;
                    RaisePropertyChanged(() => MealDate);
                    if (MealDate.Date == DateTime.Now.Date)
                    {
                        ShowDate = "Today";
                    }
                    else
                    {
                        ShowDate = MealDate.ToString("dd/MM/yyyy");

                    }
                }
            }
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
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }
        private List<Item> mealtypes_array = new List<Item>()
        {
            new Item("Breakfast"),
            new Item("Lunch"),
            new Item("Dinner"),
            new Item("Snack")

        };

        public List<Item> MealTypesArray
        {
            get { return mealtypes_array; }
            set
            {
                mealtypes_array = value;
                RaisePropertyChanged(() => MealTypesArray);
            }
        }

        private Item selectedItem = new Item("Three");

        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }

        }
        public async void addToTable()
        {
            await database.InsertTableRow(new MyTable() { MealSummary = MealContent, MealTitle = MealTitle,  MealTimestamp = MealDate.ToString("dd/MM/yyyy"), MealDate = MealDate.ToString(), UserId = UserId, MealId = GenerateMealID(),MealType = SelectedItem.Caption,Ingredients = MealIngredients,Approach = MealApproach});

        }

        public void Init(string mealId, string userid, DateTime DateIn, string selectedItem)
        {
            MealID = mealId;
            UserId = userid;
            SelectedItem = new Item(selectedItem);
            if (DateIn == DateTime.MinValue)
            {
                MealDate = DateTime.Now.Date;

            }
            else
            {
                MealDate = DateIn;
            }
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
                    var ingredients = "";
                    if (meal.Ingredients != null)
                    {
                        ingredients = meal.Ingredients.Replace(", ", "\n- ").Insert(0, "- ");
                    }

                    MealContent = meal.MealSummary;
                    MealTitle = meal.MealTitle;
                    MealApproach = meal.Approach;
                    MealIngredients = ingredients;
                    RaiseAllPropertiesChanged();
                   
                    break;
                }

            }
        }
    }
}
