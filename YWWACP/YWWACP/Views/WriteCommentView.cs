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
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Views;
using YWWACP.Core.ViewModels;
using YWWACP.Core.ViewModels.Community;

namespace YWWACP.Views
{
    // ## Name: Andreas Norstein | ## Student number: 9805061

    [MvxViewFor(typeof(WriteCommentViewModel))]
    [Activity(Label = "Community")]
    public class WriteCommentView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.WriteComment);

        }

    }
}