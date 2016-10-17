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
using MvvmCross.Droid.Views;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.ViewModels;

namespace YWWACP.Views
{
    [MvxViewFor(typeof(SingleExerciseViewModel))]
    [Activity(Label = "SingleExerciseActigdfhjkvity")]
    public class SingleExerciseView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SingleExercise);

        }

        protected override void OnResume()
        {
            var vm = (SingleExerciseViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }

    }
}