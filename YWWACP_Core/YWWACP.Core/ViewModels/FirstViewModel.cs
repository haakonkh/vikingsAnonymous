using System;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using Android.App;
using Android.Content;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using YWWACP.Core.ViewModels.Diary;

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
        public ICommand OpenDiaryCommand { get; set; }

        public ICommand DeleteEverythingCommand { get; set; }
        private readonly ISharedPreferences prefUserInfo = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
        private readonly ISharedPreferences prefAppOpend = Application.Context.GetSharedPreferences("MyPrefsFile", FileCreationMode.Private);
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenGraphCommand { get; set; }


        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public FirstViewModel(IDatabase database)
        {
            this.database = database;
            UserId = prefUserInfo.GetString("UserId", "");
            InitDb();

            OpenHealthPlanCommand = new MvxCommand(() => ShowViewModel<HealthPlanViewModel>(new { userid = UserId }));
            OpenGraphCommand = new MvxCommand(() => ShowViewModel<GraphViewModel>(new { userid = UserId }));
            OpenExerciseCommand = new MvxCommand(() => ShowViewModel<CreateNewGViewModel>(new { userid = UserId }));
            OpenRecipeCommand = new MvxCommand(() => ShowViewModel<ListExercisesViewModel>(new {userid = UserId}));
            OpenProfileCommand = new MvxCommand(() => ShowViewModel<ProfileViewModel>(new {userid = UserId}));
            OpenCommand = new MvxCommand(() => ShowViewModel<CommunityViewModel>(new {userid = UserId}));
            OpenDiaryCommand = new MvxCommand(() => ShowViewModel<DiaryViewModel>(new { userid = UserId,DateIn = DateTime.MinValue }));


            DeleteEverythingCommand = new MvxCommand(() =>
            {
                DeleteEverything();
            });
        }

        public async void DropDatabase()
        {
            var tables = await database.GetTable();
            foreach (var table in tables)
            {
                await database.DeleteTableRow(table.Id);
            }
        }

        public string GenerateID()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "").Replace("+", "");

            string GS = Convert.ToBase64String(g.ToByteArray());
            GS = GuidString.Replace("=", "").Replace("+", "");
            return GuidString + GS;
        }
        public async void DeleteEverything()
        {
            var threads = await database.GetTable();
            foreach (var thread in threads)
            {
                await database.DeleteTableRow(thread.Id);
            }
            ISharedPreferencesEditor editor1 = prefUserInfo.Edit();
            editor1.Clear();
            editor1.Apply();

            ISharedPreferencesEditor editor2 = prefAppOpend.Edit();
            editor2.Clear();
            editor2.Apply(); ;

        }

        public async void InitDb()
        {
			DropDatabase();
            await database.InsertTableRow(new MyTable
                {
                    MealId = "1",
                    MealTitle = "Stewed fruit with custard or cream",
                    MealSummary = "Godt og digg",
                    Ingredients = "3–4 pieces seasonal fruit (e.g. pear, apple, plum) - peeled, cored, chopped, 1 cup orange juice, 1 cup full - cream custard or ice - cream(or 2 tbsp cream)",
                    Approach = "Place fruit and orange juice in a medium saucepan over low heat. Cook for about 20–30 minutes, stirring occasionally until fruit softens (the total time will depend on the hardness of the fruit). Serve with some full - cream custard, ice - cream or cream",
                    basic = true,
                    UserId = ""

                }
            );

           await database.InsertTableRow(new MyTable
            {
                MealId = "2",
                MealTitle = "Tangy protein smoothie",
                MealSummary = "A thick, protein-packed drink",
                Ingredients = " cup cottage cheese or plain yogurt,  cup vanilla ice cream,  cup prepared fruit - flavored gelatin(can use individual ready - to - eat snack pack),  cup low - fat milk",
                Approach = "Mix all ingredients in a blender",
                basic = true,
                UserId = ""
            }
            );

           await database.InsertTableRow(new MyTable
            {
                MealId = "3",
                MealTitle = "Chicken and white bean soup",
                MealSummary = "easy",
                Ingredients = "1 rotisserie chicken breast section or 3 cups chopped white chicken meat, 1 tablespoon canola oil, 3 carrots - sliced, 2 celery stalks - sliced, 1 onion - chopped, 2 cups water6 cups reduced - sodium chicken broth1(15 - ounce) can Great Northern beans - rinsed and drained, Pepper and salt to taste",
                Approach = "Remove wings from chicken and reserve. Remove skin from breast and discard. Shred the meat from the breast and break off breast bones. Heat oil in a stock pot over medium heat.Sauté the carrots, celery, onion, chicken wings and breastbones for 8 to 10 minutes, or until vegetables soften. ",
                basic = true,
                UserId = ""
            }
            );

           await database.InsertTableRow(new MyTable
           {
               ExerciseId = "1",
               ExerciseTitle = "Burpess",
               ExerciseSummary = "yeah, we all know the pain",
               Sets = 3,
               Reps = 12,
               basic = true,
               UserId = ""
           });
		   
		    await database.InsertTableRow(new MyTable() { ExerciseSummary = "Run bitch, run!", ExerciseTitle = "Running", Sets = 0, Reps = 0, ExerciseId = GenerateID(), UserId = "",basic = true});
            await database.InsertTableRow(new MyTable() { ExerciseSummary = "Bounce up and down", ExerciseTitle = "Squatting", Sets = 4, Reps = 8, ExerciseId = GenerateID(),UserId = "",basic = true});
            await database.InsertTableRow(new MyTable() { ExerciseSummary = "Kick a ball", ExerciseTitle = "Football", Sets = 0, Reps = 0, ExerciseId = GenerateID() ,UserId = "",basic = true});

            await database.InsertTableRow(new MyTable()
            {
                ThreadID = "YOLOSWAGLORD",
                ThreadTitle = "YOLO, DU eier ikke meg!",
                Content = "HAhahahah, du fikk feilmelding hvis du prøvde å slette meg! LOL",
                UserId = new Guid().ToString(),
                Category = "Random"
            });

            await database.InsertTableRow(new MyTable()
            {
                ThreadID = "YOLOSWAGLORD",
                CommentID = new Guid().ToString(),
                CommentContent = "Faen, jeg ville slette deg",
                UserId = new Guid().ToString()
            });

            await database.InsertTableRow(new MyTable()
            {
                GoalId = new Guid().ToString(),
                GoalContent = "Run 6km",
                GoalDate = DateTime.Now.Date.AddDays(-5).ToString("dd/MM/yyyy"),
                GoalSatisfaction = 6.0,
                UserId = UserId
            });
            await database.InsertTableRow(new MyTable()
            {
                GoalId = new Guid().ToString(),
                GoalContent = "Run 5km",
                GoalDate = DateTime.Now.Date.AddDays(-3).ToString("dd/MM/yyyy"),
                GoalSatisfaction = 2.0,
                UserId = UserId
            });


            await database.InsertTableRow(new MyTable()
            {
                GoalId = new Guid().ToString(),
                GoalContent = "Drink 10 glasses of water",
                GoalDate = DateTime.Now.Date.AddDays(-1).ToString("dd/MM/yyyy"),
                GoalSatisfaction = 8.0,
                UserId = UserId

            });

        


        }
    }
}