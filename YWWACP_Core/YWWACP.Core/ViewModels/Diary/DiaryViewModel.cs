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
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Core.ViewModels.Diary
{
    public class DiaryViewModel:MvxViewModel
    {
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenRecipesCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }

        public IDatabase database;
        public ICommand PrevDayCommand { get; set; }
        public ICommand TodayCommand { get; set; }
        public ICommand NextDayCommand { get; set; }

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
            PrevDayCommand = new MvxCommand(() =>
            {
                Date = Date.AddDays(-1);
                RaisePropertyChanged(() => Date);
                
            });
            NextDayCommand = new MvxCommand(() =>
            {
                Date = Date.AddDays(1);
                RaisePropertyChanged(() => Date);
            });
            TodayCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryDayViewModel>(new {userId = UserId, currentDate = Date});
                Close(this);
            });

            OpenHealthPlanCommand = new MvxCommand(() =>
            {
                ShowViewModel<HealthPlanViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenHomeCommand = new MvxCommand(() =>
            {
                ShowViewModel<FirstViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenRecipesCommand = new MvxCommand(() =>
            {
                ShowViewModel<RecipeViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenExerciseCommand = new MvxCommand(() =>
            {
                ShowViewModel<CreateNewGViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenCommunityCommand = new MvxCommand(() =>
            {
                ShowViewModel<CommunityViewModel>();
                Close(this);
            });
        }
        public void Init(string userId, DateTime DateIn)
        {
            UserId = userId;
            if (DateIn == DateTime.MinValue)
            {
                Date = DateTime.Now.Date;

            }
            else
            {
                Date = DateIn;
            }
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
                    if (Date.Date == DateTime.Now.Date)
                    {
                        ShowDate = "Today";
                    }
                    else
                    {
                        ShowDate = Date.ToString("dd/MM/yyyy");

                    }
                    RaisePropertyChanged(() => ShowDate);
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
                        Entries.Insert(0, new Exercise(entry.ExerciseTitle, entry.ExerciseSummary, entry.Sets, entry.Reps, entry.ExerciseTimestamp, entry.ExerciseId));
                    }
                }

            }
            RaisePropertyChanged(() => Entries);
            if (Entries.Count == 0)
            {
                Entries.Insert(0, new Exercise("No entries for this day", "", 0, 0,"", ""));
                RaisePropertyChanged(() => Entries);
            }

        }

    }
}
