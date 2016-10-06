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
 

    [Activity(Label = "ExerciseDialog")]
    class ExerciseDialog : DialogFragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            //Forandret ( View
            var view = inflater.Inflate(Resource.Layout.exerciseDialogView, container, false);

            // Close dialog fragment
            view.FindViewById<Button>(Resource.Id.cancelBtn).Click += (sender, args) => Dismiss();

            view.FindViewById<ImageView>(Resource.Id.exerciseImage).SetImageResource(Resource.Drawable.barbell_Standing);

            // Close dialog fragment
            var addBtn = view.FindViewById<Button>(Resource.Id.addBtn);

            addBtn.Click += delegate (object sender, EventArgs args)
            {
                Toast.MakeText(Activity, "Exercise added to plan", ToastLength.Short).Show();
            };

            return view;

        }

    }
}