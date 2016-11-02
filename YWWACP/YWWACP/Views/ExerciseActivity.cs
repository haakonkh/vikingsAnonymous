using Android.App;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;
using YWWACP.Core.ViewModels.ExerciseRecipe;

//Author: Student n9808205, Student Ingrid Skar

namespace YWWACP.Views
{
    [MvxViewFor(typeof(CreateNewGViewModel))]
    [Activity(Label = "Exercises")]
    public class ExerciseActivity : MvxActivity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Exercise);


        }

        protected override void OnResume()
        {
            var vm = (CreateNewGViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }


    }
}