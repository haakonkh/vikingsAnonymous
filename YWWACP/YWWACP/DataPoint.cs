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
    public class DataPoint
    {
        public string Date { get; set; }
        public int CheckIns { get; set; }
        public int Guests { get; set; }
    }

}