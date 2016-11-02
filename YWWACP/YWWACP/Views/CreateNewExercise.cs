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
using YWWACP.Core.ViewModels.ExerciseRecipe;

//Author: Student n9808205, Student Ingrid Skar

namespace YWWACP.Views
{
    [MvxViewFor(typeof(CreateExerciseViewModel))]
    [Activity(Label = "Create new exercise")]
    class CreateNewExercise : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.exerciseDialogView);

        }
    }
}