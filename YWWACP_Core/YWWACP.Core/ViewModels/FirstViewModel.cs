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
        public ICommand OpenExerciseCommand { get; set; }
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
            OpenExerciseCommand = new MvxCommand(() => ShowViewModel<ExerciseViewModel>(new { userid = UserId }));
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
                    MealTitle = "Stewed fruit with custard or cream",
                    MealSummary = "Godt og digg",
                    Ingredients = "3–4 pieces seasonal fruit (e.g. pear, apple, plum) - peeled, cored, chopped, 1 cup orange juice, 1 cup full - cream custard or ice - cream(or 2 tbsp cream)",
                    Approach = "Place fruit and orange juice in a medium saucepan over low heat. Cook for about 20–30 minutes, stirring occasionally until fruit softens (the total time will depend on the hardness of the fruit). Serve with some full - cream custard, ice - cream or cream"

                }
            );

            database.InsertTableRow(new MyTable
            {
                MealId = "2",
                MealTitle = "Tangy protein smoothie",
                MealSummary = "A thick, protein-packed drink",
                Ingredients = " cup cottage cheese or plain yogurt,  cup vanilla ice cream,  cup prepared fruit - flavored gelatin(can use individual ready - to - eat snack pack),  cup low - fat milk",
                Approach = "Mix all ingredients in a blender"
            }
            );

            database.InsertTableRow(new MyTable
            {
                MealId = "3",
                MealTitle = "Chicken and white bean soup",
                MealSummary = "easy",
                Ingredients = "1 rotisserie chicken breast section or 3 cups chopped white chicken meat, 1 tablespoon canola oil, 3 carrots - sliced, 2 celery stalks - sliced, 1 onion - chopped, 2 cups water6 cups reduced - sodium chicken broth1(15 - ounce) can Great Northern beans - rinsed and drained, Pepper and salt to taste",
                Approach = "Remove wings from chicken and reserve. Remove skin from breast and discard. Shred the meat from the breast and break off breast bones. Heat oil in a stock pot over medium heat.Sauté the carrots, celery, onion, chicken wings and breastbones for 8 to 10 minutes, or until vegetables soften. "
            }
            );

           database.InsertTableRow(new MyTable
           {
               ExerciseId = "1",
               ExerciseTitle = "Burpess",
               ExerciseSummary = "yeah, we all know the pain",
               Sets = 3,
               Reps = 12
           });





        }
    }
}