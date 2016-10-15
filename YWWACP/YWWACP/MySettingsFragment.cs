using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Views;
using YWWACP.Core;
using MvvmCross.Droid.Support.V7.Fragging.Attributes;
using MvvmCross.Droid.Support.V7.Fragging.Fragments;
//using MvvmCross.Droid.FullFragging;
using MvvmCross.Core.ViewModels;
//using MvvmCross.Droid.FullFragging.Fragments;
//using MvvmCross.Droid.Shared.Attributes;
using MvvmCross.Droid.Support.V7;
using YWWACP;
using YWWACP.Core.ViewModels;

namespace YWWACP
{
    [MvxFragmentAttribute(typeof(MainViewModel), Resource.Id.frameLayout)]
    [Activity(Label = "MySettingsFragment")]
   // [Register("MySettingsFragment")]
    public class MySettingsFragment : MvxFragment<MySettingsViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MySettingsView, container, false);
        }

        public MySettingsFragment(){}
    }
}