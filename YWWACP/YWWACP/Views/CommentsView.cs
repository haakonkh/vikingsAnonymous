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
using MvvmCross.Droid.Views;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.ViewModels;

namespace YWWACP.Views
{
    [MvxViewFor(typeof(CommentsViewModel))]
    [Activity(Label = "CommentsActivity")]
    public class CommentsView : MvxActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Comments);

        }

        protected override void OnResume()
        {
            var vm = (CommentsViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }

    }
}