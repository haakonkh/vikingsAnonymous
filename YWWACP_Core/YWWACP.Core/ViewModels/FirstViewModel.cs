using MvvmCross.Core.ViewModels;
using System.Windows.Input;

namespace YWWACP.Core.ViewModels
{
    public class FirstViewModel
        : MvxViewModel
    {
        public ICommand OpenCommand { get; set; }

        public FirstViewModel()
        {
            OpenCommand = new MvxCommand(() => ShowViewModel<CommunityViewModel>());
        }

    }
}