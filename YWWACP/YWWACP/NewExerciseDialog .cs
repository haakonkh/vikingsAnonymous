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
    class NewExerciseDialog : DialogFragment
    {

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            //Forandret ( View
            var view = inflater.Inflate(Resource.Layout.exerciseDialogNewExer, container, false);

            // Close dialog fragment
             var addBtn = view.FindViewById<Button>(Resource.Id.addBtnExercise);

            // Close dialog fragment
            view.FindViewById<Button>(Resource.Id.cancelBtnExercise).Click += (sender, args) => Dismiss();

            addBtn.Click += delegate (object sender, EventArgs args)
                {


                    //LEgge til i database kode

                    Toast.MakeText(Activity, "New exercise created", ToastLength.Short).Show();
               };

            return view;

        }

    }
}