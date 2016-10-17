using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Core.ViewModels.Diary
{
    public class DiaryViewModel:MvxViewModel
    {
        public IDatabase database;
        private ObservableCollection<Exercise> entries = new ObservableCollection<Exercise>();
        public ObservableCollection<Exercise> Entries
        {
            get { return entries; }
            set
            {
                SetProperty(ref entries, value);

            }

        }

        public DiaryViewModel(IDatabase database)
        {
            this.database = database;
            GetDiary();
            //OpenExerciseCommand = new MvxCommand(() => ShowViewModel<HealthPlanExerciseViewModel>(new { userid = UserId }));


        }
        public void Init(string userId)
        {
            UserId = userId;
            Date = DateTime.Now.Date;
            RaisePropertyChanged(() => Date);
        }
        public void OnResume()
        {
            GetDiary();
        }
        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                if (value != date)
                {
                    date = value;
                    GetDiary();
                    RaisePropertyChanged(() => Date);
                    
                }
            }
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        private async void GetDiary()
        {
            var entries = await database.GetTable();
            Entries.Clear();
            foreach (var entry in entries)
            {
                
                if (entry.ExerciseTimestamp != null && entry.UserId == UserId)
                {
                    DateTime dt = Convert.ToDateTime(entry.ExerciseDate);

                    if (dt.Date == Date.Date)
                    {
                        Entries.Insert(0, new Exercise(entry.ExerciseTitle, entry.ExerciseContent, entry.Sets, entry.Reps, entry.ExerciseTimestamp, entry.ExerciseId));
                    }
                }

            }
            RaisePropertyChanged(() => Entries);

        }

    }
}
