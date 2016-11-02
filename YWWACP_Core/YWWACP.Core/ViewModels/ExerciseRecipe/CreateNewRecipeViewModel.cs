using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

//Author: Student n9808205, Student Ingrid Skar

namespace YWWACP.Core.ViewModels.ExerciseRecipe
{
    public class CreateNewRecipeViewModel : MvxViewModel
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

        private string ingredients;

        public string Ingredients
        {
            get { return ingredients; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref ingredients, value);
                }

            }
        }

        private string approach;

        public string Approach
        {
            get { return approach; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref approach, value);
                }

            }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public CreateNewRecipeViewModel(IDatabase database)
        {
            this.database = database;
            var t = new MyTable();
            SubmitCommand = new MvxCommand(() =>
            {
                
                CreateRecipe(new MyTable()
                {
                    MealId = GetGeneratedExerciseId(),
                    MealTitle = Title,
                    MealSummary = Summary,
                    Ingredients = ingredients,
                    Approach = approach,
                    basic = true

                });
            });
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public async void CreateRecipe(MyTable exercise)
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