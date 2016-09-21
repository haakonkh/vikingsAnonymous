using System;

using Android.App;
using Android.OS;
using Android.Widget;
namespace YWWACP
{

    [Activity(Label = "ExerciseActivity")]
     public class ExerciseActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ExerciseMain);

            var gridview = FindViewById<GridView>(Resource.Id.grid);

            gridview.Adapter = new GridAdapter_exercise(this);

            gridview.ItemClick += exercise_Click;
        }

        private void exercise_Click(object sender, EventArgs e)
        {
            Console.WriteLine(e);
            
            FragmentTransaction transaction = FragmentManager.BeginTransaction();

            ExerciseDialog newRecipeDialog= new ExerciseDialog();

            newRecipeDialog.Show(transaction, "dialog fragment");

        }



    }
}