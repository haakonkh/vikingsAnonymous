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
    public class dialog_new_thread : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            // Needs to be changed to the acutally dialog window.
            // Not created
            var view = inflater.Inflate(Resource.Layout.Dialog_New_Thread, container, false);

            return view;

        }
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // Sets the titlebar to invisible
            base.OnActivityCreated(savedInstanceState);
        }

    }
}