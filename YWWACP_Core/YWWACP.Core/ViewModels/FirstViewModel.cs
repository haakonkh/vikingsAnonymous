using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using Android.App;
using Android.Content;
using YWWACP.Core.Interfaces;

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
            DeleteEverythingCommand = new MvxCommand(() =>
            {
                DeleteEverything();
            });
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