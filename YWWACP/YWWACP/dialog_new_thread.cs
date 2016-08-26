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
    [Activity(Label = "dialog_new_thread")]
    class dialog_new_thread : DialogFragment
    {
        private Spinner dropdown; 

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.Dialog_New_Thread, container, false);

            // Cancels the new thread
            view.FindViewById<Button>(Resource.Id.btnCancelThread).Click += (sender, args) => Dismiss();

            dropdown = view.FindViewById<Spinner>(Resource.Id.spinnerCategories);
            dropdown.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);

            var adapter = ArrayAdapter.CreateFromResource(Activity, Resource.Array.categories_array, Android.Resource.Layout.SimpleSpinnerItem);
            adapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            dropdown.Adapter = adapter;
       
            return view;

        }
        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            Spinner spinner = (Spinner)sender;

            string toast = string.Format("The category is {0}", spinner.GetItemAtPosition(e.Position));
            Toast.MakeText(Activity, toast, ToastLength.Long).Show();
        }


        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // Sets the titlebar to invisible
            base.OnActivityCreated(savedInstanceState);

        
        }

    }
}