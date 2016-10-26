using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    public class ExercisePickDay:MvxViewModel
    {
        public IDatabase database;
        public ICommand BackToExerciseCommand { get; set; }
        public ExercisePickDay(IDatabase database)
        {
            this.database = database;
            BackToExerciseCommand = new MvxCommand(() =>
            {
                ShowViewModel<ExerciseDetailsViewModel>(new { exerciseId = ExerciseID, userId = UserId, DateIn = Date});
                Close(this);
            });

        }
        public void Init(string exerciseId, string userId, DateTime currentDate)
        {
            UserId = userId;
            Date = currentDate;
            ExerciseID = exerciseId;
            RaisePropertyChanged(ExerciseID);
            RaisePropertyChanged(UserId);
        }
        private string exerciseID;

        public string ExerciseID
        {
            get { return exerciseID; }
            set { SetProperty(ref exerciseID, value); }
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
