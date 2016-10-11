using MvvmCross.Core.ViewModels;
using System.Windows.Input;
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
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public FirstViewModel(IDatabase database)
        {
            this.database = database;
            OpenProfileCommand = new MvxCommand(() => ShowViewModel<ProfileViewModel>(new { userid = UserId}));
            OpenCommand = new MvxCommand(() => ShowViewModel<CommunityViewModel>(new {userid = UserId }));
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

    }
}