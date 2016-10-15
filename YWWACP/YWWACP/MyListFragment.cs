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
    [Activity(Label = "MyListFragment")]

    [Register("MyListFragment")]
    public class MyListFragment : MvxFragment<MyListViewModel>
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.MyListView, container, false);
        }

        public MyListFragment() { }
    }
}