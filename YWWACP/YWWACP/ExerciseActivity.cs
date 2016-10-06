using System;

using Android.App;
using Android.OS;
using Android.Widget;
namespace YWWACP
{

    [Activity(Label = "ExerciseActivity")]
    public class ExerciseActivity : Activity
    {

        private Button btnNewExer;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ExerciseMain);

            btnNewExer = FindViewById<Button>(Resource.Id.btnNewExer);

            var gridview = FindViewById<GridView>(Resource.Id.grid);

            gridview.Adapter = new GridAdapter_exercise(this);
            gridview.ItemClick += exercise_Click;

            btnNewExer.Click += NewExercise_Click;
        }

        private void exercise_Click(object sender, EventArgs e)
        {
            Console.WriteLine(e);

            FragmentTransaction transaction = FragmentManager.BeginTransaction();

            ExerciseDialog newRecipeDialog = new ExerciseDialog();

            newRecipeDialog.Show(transaction, "dialog fragment");

        }




        private void NewExercise_Click(object sender, EventArgs e)
        {
            //New exercise button

            Console.WriteLine(e);

            FragmentTransaction transaction = FragmentManager.BeginTransaction();

            NewExerciseDialog newRecipeDialog = new NewExerciseDialog();

            newRecipeDialog.Show(transaction, "dialog fragment");

        }




        private void newexercise_Click(object sender, EventArgs e)
        {
            Console.WriteLine(e);

            FragmentTransaction transaction = FragmentManager.BeginTransaction();

            ExerciseDialog newRecipeDialog = new ExerciseDialog();

            newRecipeDialog.Show(transaction, "dialog fragment");

        }



    }
}