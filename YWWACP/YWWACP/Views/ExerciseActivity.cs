using Android.App;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;

namespace YWWACP.Views
{
    [MvxViewFor(typeof(ListExerciseViewModel))]
    [Activity(Label = "ExerciseActivity")]
    public class ExerciseActivity : MvxActivity
    {


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Exercise);


        }

        protected override void OnResume()
        {
            var vm = (ListExerciseViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }


    }
}