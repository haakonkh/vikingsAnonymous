using System;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using Android.App;
using Android.Content;
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
        public ICommand DeleteEverythingCommand { get; set; }
        private readonly ISharedPreferences prefUserInfo = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
        private readonly ISharedPreferences prefAppOpend = Application.Context.GetSharedPreferences("MyPrefsFile", FileCreationMode.Private);
        public ICommand OpenHealthPlanCommand { get; set; }


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
            
            OpenProfileCommand = new MvxCommand(() => ShowViewModel<ProfileViewModel>(new { userid = UserId}));
            OpenCommand = new MvxCommand(() => ShowViewModel<CommunityViewModel>(new {userid = UserId }));
            OpenHealthPlanCommand = new MvxCommand(() => ShowViewModel<HealthPlanViewModel>(new { userid = UserId }));
            DeleteEverythingCommand = new MvxCommand(() =>
            {
                DeleteEverything();
            });
        }
        public void Init(string userId)
        {
            initDatabase();
            
        }
        public async void DropDatabase()
        {
            var tables = await database.GetTable();
            foreach (var table in tables)
            {
                await database.DeleteTableRow(table.Id);
            }
        }
        async void initDatabase()
        {
            DropDatabase();
            await database.InsertTableRow(new MyTable() { ExerciseContent = "Run bitch, run!", ExerciseTittle = "Running", Sets = 0, Reps = 0, ExerciseId = GenerateID(), UserId = "",basic = true});
            await database.InsertTableRow(new MyTable() { ExerciseContent = "Bounce up and down", ExerciseTittle = "Squatting", Sets = 4, Reps = 8, ExerciseId = GenerateID(),UserId = "",basic = true});
            await database.InsertTableRow(new MyTable() { ExerciseContent = "Kick a ball", ExerciseTittle = "Football", Sets = 0, Reps = 0, ExerciseId = GenerateID() ,UserId = "",basic = true});

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

    }
}