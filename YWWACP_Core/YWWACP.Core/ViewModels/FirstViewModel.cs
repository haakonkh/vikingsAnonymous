using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        public IDatabase database;
        public ICommand OpenCommand { get; set; }
        public ICommand OpenProfileCommand { get; set; }
        public ICommand OpenRecipeCommand { get; set; }
        public ICommand DeleteEverythingCommand { get; set; }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public FirstViewModel(IDatabase database)
        {
            this.database = database;
            InitDb();
            OpenRecipeCommand = new MvxCommand(() => ShowViewModel<RecipeViewModel>(new {userid = UserId}));
            OpenProfileCommand = new MvxCommand(() => ShowViewModel<ProfileViewModel>(new {userid = UserId}));
            OpenCommand = new MvxCommand(() => ShowViewModel<CommunityViewModel>(new {userid = UserId}));
            DeleteEverythingCommand = new MvxCommand(() =>
            {
                DeleteEverything();
            });
        }

        public void Init(string userid)
        {
            UserId = userid;
        }


        public async void DeleteEverything()
        {
            var threads = await database.GetTable();
            foreach (var thread in threads)
            {
                await database.DeleteTableRow(thread.Id);
            }
        }

        public void InitDb()
        {
            DeleteEverything();
            database.InsertTableRow(new MyTable
                {
                    MealId = "1",
                    MealTitle = "Pasta Bolognese",
                    MealSummary = "Godt og digg",
                    Ingredients = "Pasta;",
                    Approach = "Kok"
                }
            );

            database.InsertTableRow(new MyTable
            {
                MealId = "2",
                MealTitle = "Laks i pesto",
                MealSummary = "Laks med pasta og pesto",
                Ingredients = "Laks, pasta, pesto",
                Approach = "Stek"
            }
            );

            database.InsertTableRow(new MyTable
            {
                MealId = "3",
                MealTitle = "Nachos",
                MealSummary = "easy",
                Ingredients = "Mexican",
                Approach = "easy fix"
            }
            );

            database.InsertTableRow(new MyTable
            {
                MealId = "4",
                MealTitle = "Tuna and veggies",
                MealSummary = "slankemat",
                Ingredients = "tuna",
                Approach = "stek i masse seasioning"
            }
            );

           

         

        }
    }
}