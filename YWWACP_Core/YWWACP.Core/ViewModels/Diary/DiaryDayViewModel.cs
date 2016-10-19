using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.ViewModels.Diary
{
    public class DiaryDayViewModel: MvxViewModel
    {
        public IDatabase database;
        public ICommand BackToDiaryCommand { get; set; }
        public DiaryDayViewModel(IDatabase database)
        {
            this.database = database;
            BackToDiaryCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryViewModel>(new {userId = UserId, DateIn = Date});
                Close(this);
            });

        }
        public void Init(string userId, DateTime currentDate)
        {
            UserId = userId;
            Date = currentDate;
            RaisePropertyChanged(() => Date);

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
