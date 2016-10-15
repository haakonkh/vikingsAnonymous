using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using MvvmCross.Core.ViewModels;
using YWWACP.Core;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
using YWWACP.Core.ViewModels;


namespace YWWACP.Views
{
    //[MvxFragment(typeof(MainViewModel), Resource.Id.frameLayout)]
    [MvxViewFor(typeof(ProfileViewModel))]
    [Register("YWWACP.Profile")]
    public class ProfileActivity :  MvxFragment<ProfileViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.Profile, container, false);
        }

        public ProfileActivity() { }
    }


    //MvxActivity
    //{

    //    protected override void OnCreate(Bundle savedInstanceState)
    //    {
    //        base.OnCreate(savedInstanceState);
    //        // Set our view from the "main" layout resource
    //        SetContentView(Resource.Layout.Profile);
    //    }

    //    protected override void OnResume()
    //    {
    //        var vm = (ProfileViewModel)ViewModel;
    //        vm.OnResume();
    //        base.OnResume();
    //    }
    //}
}



