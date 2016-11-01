using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android.Content;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class CreateExerciseViewModel : MvxViewModel
    {
        private IDatabase database;
        public ICommand SubmitCommand { get; set; }

        public ICommand CancelCommand
        {
            get { return new MvxCommand(() => Close(this)); }
        }

        public ICommand GoBackCommand { get; set; }

        public IMvxCommand GoToTakePictureScreenCommand => new MvxCommand(() => ShowViewModel<TakePictureViewModel>());

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref title, value);
                }
            }
        }

        private string summary;

        public string Summary
        {
            get { return summary; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref summary, value);
                }
            }
        }

        private string sets;

        public string Sets
        {
            get { return sets; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref sets, value);
                }

            }
        }

        private string reps;

        public string Reps
        {
            get { return reps; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref reps, value);
                }

            }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public CreateExerciseViewModel(IDatabase database)
        {
            this.database = database;
            var t = new MyTable();
            SubmitCommand = new MvxCommand(() =>
            {
                int set = Int32.Parse(sets);
                int rep = Int32.Parse(reps);
                CreateExercise(new MyTable()
                {
                    ExerciseId = GetGeneratedExerciseId(),
                    ExerciseTitle = Title,
                    ExerciseSummary = Summary,
                    Sets = set,
                    Reps = rep,
                    basic = true

                });
            });
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public async void CreateExercise(MyTable exercise)
        {
            var x = await database.InsertTableRow(exercise);
            Close(this);

        }

        public string GetGeneratedExerciseId()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            string GS = Convert.ToBase64String(g.ToByteArray());
            GS = GuidString.Replace("=", "");
            GS = GuidString.Replace("+", "");
            return GuidString + GS;
        }

    }


}