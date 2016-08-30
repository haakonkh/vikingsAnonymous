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

namespace YWWACP
{
    [Activity(Label = "RecipesActivity")]
    public class RecipesActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

			SetContentView(Resource.Layout.RecipeMain);

			var gridview = FindViewById<GridView>(Resource.Id.grid);

			gridview.Adapter = new GridAdapter(this);

			gridview.ItemClick += recipe_Click;
        }

		private void recipe_Click(object sender, EventArgs e)
		{
			Console.WriteLine(e);

			FragmentTransaction transaction = FragmentManager.BeginTransaction();

			RecipeDialog newRecepieDialog = new RecipeDialog();

			newRecepieDialog.Show(transaction, "dialog fragment");

		}
    }
}