using Android.App;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;
using YWWACP.Core.ViewModels.ExerciseRecipe;

//Author: Student n9808205, Student Ingrid Skar

namespace YWWACP.Views
{
    [MvxViewFor(typeof(RecipeViewModel))]
    [Activity(Label = "Recipes")]
    public class RecipeActivity : MvxActivity
    {
      

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Recipes);

           
        }

        protected override void OnResume()
        {
            var vm = (RecipeViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }

       
    }
}