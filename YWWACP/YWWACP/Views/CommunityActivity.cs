using Android.App;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;
using YWWACP.Core.ViewModels.Community;

//Author: Student 9805061, Student Andreas Norstein
namespace YWWACP.Views
{
    [MvxViewFor(typeof(CommunityViewModel))]
    [Activity(Label = "Community")]
    public class CommunityActivity : MvxActivity
    {
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Community);
            
        }

        protected override void OnResume()
        {
            var vm = (CommunityViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
        
    }


}