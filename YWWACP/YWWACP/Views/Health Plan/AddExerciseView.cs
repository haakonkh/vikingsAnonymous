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
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Views.Health_Plan
{
    [MvxViewFor(typeof(AddExerciseViewModel))]
    [Activity(Label = "Add exercise")]
    public class AddExerciseView: MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.AddExerciseToPlan);

        }
    }
}