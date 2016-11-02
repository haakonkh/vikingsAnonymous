using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;
using YWWACP.Core.ViewModels.Community;

namespace YWWACP.Views
{
    // ## Name: Andreas Norstein | ## Student number: 9805061

    [MvxViewFor(typeof(MyThreadsViewModel))]
    [Activity(Label = "My Posts")]
    public class MyThreadsView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.MyThreads);

        }

        protected override void OnResume()
        {
            var vm = (MyThreadsViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }

    }
}