using System;
using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;
using YWWACP.Core.ViewModels.Profile;


namespace YWWACP.Views
{
    // ## Name: Andreas Norstein | ## Student number: 9805061

    [Activity(Label = "Profile")]
    [MvxViewFor(typeof(ProfileViewModel))]
    public class ProfileActivity : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Profile);
        }

        protected override void OnResume()
        {
            var vm = (ProfileViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
    }
}



