using System;
using System.Threading.Tasks;
using Android.App;
using Android.OS;
using Android.Views;
using Android.Widget;

namespace YWWACP
{
	[Activity(Label = "RecepieDialog")]
	class RecepieDialog : DialogFragment
	{

		public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);

			var view = inflater.Inflate(Resource.Layout.recipeDialogView, container, false);

			// Close dialog fragment
			view.FindViewById<Button>(Resource.Id.cancelBtn).Click += (sender, args) => Dismiss();

			view.FindViewById<ImageView>(Resource.Id.recepieImage).SetImageResource(Resource.Drawable.recipeIcon);

			// Close dialog fragment
			var addBtn = view.FindViewById<Button>(Resource.Id.addBtn);

			addBtn.Click += delegate (object sender, EventArgs args)
			{
				Toast.MakeText(Activity, "Recipe added to plan", ToastLength.Short).Show();
			};

			return view;

		}

	}
}

