using Android.App;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YWWACP.Core.ViewModels
{
    public class CommunityViewModel : MvxViewModel
    {

 
        
        public ICommand NewThreadCommand { get; set; }
        public CommunityViewModel()
        { 
            NewThreadCommand = new MvxCommand(() =>
            {
             
               
            });

        }

    }
}
