using System;
using System.Windows.Input;
using Android.App;
using Android.Content;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

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
            ShowViewModel<FirstViewModel>();
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
            //await database.InsertTableRow(new MyTable()
            //{
            //    Age = "Some old bitch",
            //    Height = "184.0",
            //    Weight = "77.0",
            //    Name = "Some old nasty chick's name",
            //    UserId = UserId
            //});
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

            await database.InsertTableRow(new MyTable() { ExerciseSummary = "Run bitch, run!", ExerciseTitle = "Running", Sets = 0, Reps = 0, ExerciseId = GetGeneratedUserId(), UserId = "", basic = true });
            await database.InsertTableRow(new MyTable() { ExerciseSummary = "Bounce up and down", ExerciseTitle = "Squatting", Sets = 4, Reps = 8, ExerciseId = GetGeneratedUserId(), UserId = "", basic = true });
            await database.InsertTableRow(new MyTable() { ExerciseSummary = "Kick a ball", ExerciseTitle = "Football", Sets = 0, Reps = 0, ExerciseId = GetGeneratedUserId(), UserId = "", basic = true });

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
