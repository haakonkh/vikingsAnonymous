using System;
using System.Windows.Input;
using Android.App;
using Android.Content;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using YWWACP.Core.ViewModels.Goal;

namespace YWWACP.Core.ViewModels.Profile
{
    public class EditProfileFirstTimeViewModel : MvxViewModel
    {
        public ICommand SaveProfileCommand { get; set; }
        public IDatabase database;
       

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref name, value);
                }
            }
        }

        private string height;

        public string Height
        {
            get { return height; }
            set
            {
                if (height != value)
                {
                    SetProperty(ref height, value);
                }
            }
        }

        private string weight;

        public string Weight
        {
            get { return weight; }
            set
            {
                if (weight != value)
                {
                    SetProperty(ref weight, value);
                }
            }
        }

        private string age;

        public string Age
        {
            get { return age; }
            set
            {
                if (age != value)
                {
                    SetProperty(ref age, value);
                }
            }
        }

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public EditProfileFirstTimeViewModel(IDatabase database)
        {
            
            this.database = database;
            UserId = GetGeneratedUserId();
            InitDb();


            SaveProfileCommand = new MvxCommand(()=>
            {
                SaveUserChanges(new MyTable()
                {
                    Name = Name,
                    Age = Age,
                    Weight = Weight,
                    Height = Height,
                    UserId = UserId
                });
                ISharedPreferences pref = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
                ISharedPreferencesEditor editor = pref.Edit();
                editor.PutString("UserId", UserId);
                editor.Apply();
              });
        }

        public async void SaveUserChanges(MyTable userinfo)
        {
            var x = await database.InsertTableRow(userinfo);
            ShowViewModel<GraphViewModel>(new {userid = UserId});
            Close(this);
        }

        public string GetGeneratedUserId()
        {
            var id = "";
            for (var i = 0; i < 3; i++)
            {
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");
                id += GuidString;
            }
            return id;
        }

        public async void DropDatabase()
        {
            var tables = await database.GetTable();
            foreach (var table in tables)
            {
                await database.DeleteTableRow(table.Id);
            }
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

            });

            await database.InsertTableRow(new MyTable
            {
                MealId = "2",
                MealTitle = "Tangy protein smoothie",
                MealSummary = "A thick, protein-packed drink",
                Ingredients = " cup cottage cheese or plain yogurt,  cup vanilla ice cream,  cup prepared fruit - flavored gelatin(can use individual ready - to - eat snack pack),  cup low - fat milk",
                Approach = "Mix all ingredients in a blender",
                basic = true,
                UserId = ""
            });

            await database.InsertTableRow(new MyTable
            {
                MealId = "3",
                MealTitle = "Chicken and white bean soup",
                MealSummary = "easy",
                Ingredients = "1 rotisserie chicken breast section or 3 cups chopped white chicken meat, 1 tablespoon canola oil, 3 carrots - sliced, 2 celery stalks - sliced, 1 onion - chopped, 2 cups water6 cups reduced - sodium chicken broth1(15 - ounce) can Great Northern beans - rinsed and drained, Pepper and salt to taste",
                Approach = "Remove wings from chicken and reserve. Remove skin from breast and discard. Shred the meat from the breast and break off breast bones. Heat oil in a stock pot over medium heat.Sauté the carrots, celery, onion, chicken wings and breastbones for 8 to 10 minutes, or until vegetables soften. ",
                basic = true,
                UserId = ""
            });

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

            await database.InsertTableRow(new MyTable() { ExerciseSummary = "Run with a stable speed for the entire workout.", ExerciseTitle = "Running", Sets = 0, Reps = 0, ExerciseId = GetGeneratedUserId(), UserId = "", basic = true });
            await database.InsertTableRow(new MyTable() { ExerciseSummary = "Sit back and down like you're sitting into an imaginary chair. Lower down so your thighs are as parallel to the floor as possible, with your knees over your ankles. Press your weight back into your heels. Keep your body tight, and push through your heels to bring yourself back to the starting position.",
                ExerciseTitle = "Squatting", Sets = 4, Reps = 8, ExerciseId = GetGeneratedUserId(), UserId = "", basic = true });
            await database.InsertTableRow(new MyTable() { ExerciseSummary = "Kick a ball", ExerciseTitle = "Football", Sets = 0, Reps = 0, ExerciseId = GetGeneratedUserId(), UserId = "", basic = true });

            await database.InsertTableRow(new MyTable()
            {
                ThreadID = "YOLOSWAGLORD",
                ThreadTitle = "What are people doing today?",
                Content = "I need som motivation to do something fun tonight, do anyone have any ideas?",
                UserId = new Guid().ToString(),
                Category = "Random"
            });

            await database.InsertTableRow(new MyTable()
            {
                ThreadID = "YOLOSWAGLORD",
                CommentID = new Guid().ToString(),
                CommentContent = "You can go for a run!",
                UserId = new Guid().ToString()
            });

            await database.InsertTableRow(new MyTable()
            {
                ThreadID = "YOLOSWAGLORD",
                CommentID = new Guid().ToString(),
                CommentContent = "Go out and eat dinner with your friends! That is always fun!",
                UserId = new Guid().ToString()
            });


            await database.InsertTableRow(new MyTable()
            {
                GoalId = new Guid().ToString(),
                GoalContent = "Run 6km",
                GoalDate = DateTime.Now.Date.AddDays(+4).ToString("dd/MM/yyyy"),
                GoalSatisfaction = 6.0,
                UserId = UserId
            });
            await database.InsertTableRow(new MyTable()
            {
                GoalId = new Guid().ToString(),
                GoalContent = "Run 5km",
                GoalDate = DateTime.Now.Date.AddDays(-3).ToString("dd/MM/yyyy"),
                GoalSatisfaction = 6,
                UserId = UserId
            });
          

            await database.InsertTableRow(new MyTable()
            {
                GoalId = new Guid().ToString(),
                GoalContent = "Drink 10 glasses of water",
                GoalDate = DateTime.Now.Date.AddDays(1).ToString("dd/MM/yyyy"),
                GoalSatisfaction = 8.0,
                UserId = UserId

            });

            await database.InsertTableRow(new MyTable()
            {
                GoalId = new Guid().ToString(),
                GoalContent = "Call an old friend",
                GoalDate = DateTime.Now.Date.AddDays(-4).ToString("dd/MM/yyyy"),
                GoalSatisfaction = 10.0,
                UserId = UserId

            });

            await database.InsertTableRow(new MyTable()
            {
                GoalId = new Guid().ToString(),
                GoalContent = "Workout two times!",
                GoalDate = DateTime.Now.Date.AddDays(-2).ToString("dd/MM/yyyy"),
                GoalSatisfaction = 5,
                UserId = UserId

            });
        }
    }
}
