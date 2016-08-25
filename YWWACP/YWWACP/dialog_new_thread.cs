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
        private Button mBtnCancelThread;

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            
            var view = inflater.Inflate(Resource.Layout.Dialog_New_Thread, container, false);

            view.FindViewById<Button>(Resource.Id.btnCancelThread).Click += (sender, args) => Dismiss();

            return view;

        }

        
        public override void OnActivityCreated(Bundle savedInstanceState)
        {
            Dialog.Window.RequestFeature(WindowFeatures.NoTitle); // Sets the titlebar to invisible
            base.OnActivityCreated(savedInstanceState);

        
        }

    }
}