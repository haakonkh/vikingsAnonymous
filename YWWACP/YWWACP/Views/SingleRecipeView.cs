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
using YWWACP.Core.ViewModels.ExerciseRecipe;

//Author: Student n9808205, Student Ingrid Skar

namespace YWWACP.Views
{
    [MvxViewFor(typeof(SingleRecipeViewModel))]
    [Activity(Label = "Recipe")]
    public class SingleRecipeView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.SingleRecipe);

        }

        protected override void OnResume()
        {
            var vm = (SingleRecipeViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }

    }
}