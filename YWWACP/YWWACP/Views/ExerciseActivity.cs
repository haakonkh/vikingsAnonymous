using Android.App;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;

namespace YWWACP.Views
{
    [MvxViewFor(typeof(ExerciseViewModel))]
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
            var vm = (ExerciseViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }


    }
}