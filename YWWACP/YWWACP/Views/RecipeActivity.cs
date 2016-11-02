using Android.App;
using Android.Graphics;
using Android.OS;
using Android.Views;
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
        private View layout;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Recipes);

            layout = FindViewById<View>(Resource.Id.recipesImage);
            layout.SetBackgroundColor(Color.DeepPink);
            layout.Visibility = ViewStates.Visible;


        }

        protected override void OnResume()
        {
            var vm = (RecipeViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }

       
    }
}