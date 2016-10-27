using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Diary;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    public class MealPickDate:MvxViewModel
    {
        public IDatabase database;
        public ICommand BackToMealCommand { get; set; }
        public MealPickDate(IDatabase database)
        {
            this.database = database;
            BackToMealCommand = new MvxCommand(() =>
            {
                ShowViewModel<MealDetailsViewModel>(new { mealID = MealID, userid = UserId, DateIn = Date, selectedItem = SelectedItem });
                Close(this);
            });

        }
        public void Init(string mealId,string userid, DateTime currentDate, string selectedItem)
        {
            UserId = userid;
            Date = currentDate;
            SelectedItem = selectedItem;
            MealID = mealId;
            RaisePropertyChanged(MealID);
            RaisePropertyChanged(UserId);
        }
        private string mealID;

        public string MealID
        {
            get { return mealID; }
            set { SetProperty(ref mealID, value); }
        }
        private string selectedItem;

        public string SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }

        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }


        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value != null && value != date)
                {
                    date = value;
                    RaisePropertyChanged(() => Date);
                }
            }
        }
    }
}
