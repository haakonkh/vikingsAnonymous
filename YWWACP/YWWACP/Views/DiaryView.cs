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
using YWWACP.Core.ViewModels.Diary;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Views
{
    [MvxViewFor(typeof(DiaryViewModel))]
    [Activity(Label = "Diary")]
    public class DiaryView: MvxActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Diary);
        }
        
        protected override void OnResume()
        {
            var vm = (DiaryViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
    }

}