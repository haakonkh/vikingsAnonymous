using System;
using Android.App;
using Android.OS;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;


namespace YWWACP.Views
{
    [Activity(Label = "Profile")]
    [MvxViewFor(typeof(ProfileViewModel))]
    public class ProfileActivity : MvxActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
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


