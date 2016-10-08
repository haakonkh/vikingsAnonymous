using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace YWWACP.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        
        public ICommand OpenCommand { get; set; }
        public ICommand OpenProfileCommand { get; set; }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public FirstViewModel()
        {
            OpenProfileCommand = new MvxCommand(() => ShowViewModel<ProfileViewModel>(new { userid = UserId}));
            OpenCommand = new MvxCommand(() => ShowViewModel<CommunityViewModel>(new {userid = UserId }));
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

    }
}