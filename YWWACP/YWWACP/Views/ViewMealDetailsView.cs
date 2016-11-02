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

namespace YWWACP.Views
{
    //Author: Student 9792538, Eirik Baug
    [MvxViewFor(typeof(ViewMealDetailsViewModel))]
    [Activity(Label = "Meal details")]
    public class ViewMealDetailsView: MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ViewMealDetails);

        }
        protected override void OnResume()
        {
            var vm = (ViewMealDetailsViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
    }
}