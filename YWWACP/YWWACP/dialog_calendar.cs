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
    public class dialog_calendar : DialogFragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            // Needs to be changed to the acutally dialog window.
            // Not created
            var view = inflater.Inflate(Resource.Layout.Dialog_calendar, container, false);

            return view;

        }
    }
}