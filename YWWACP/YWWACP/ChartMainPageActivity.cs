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
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using YWWACP.Core.ViewModels;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;
using MvvmCross.Binding.BindingContext;

//Author: Student 9787283, Student Kristoffer Helgesen 
namespace YWWACP
{

    //Sets the connection to the mView.
    [MvxViewFor(typeof(GraphViewModel))]
    [Activity(Label = "Your Progress")]
    public class ChartMainPageActivity : MvxActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.ChartMainPage);
            
            }


        protected override void OnResume()
        {
            var vm = (GraphViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }


    }
}
