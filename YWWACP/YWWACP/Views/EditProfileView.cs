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

namespace YWWACP.Views
{
    [Activity(Label = "EditProfile")]
    [MvxViewFor(typeof(EditProfileViewModel))]
    public class EditProfileView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditProfile);
        }
    }


    // This will only be used for first time registration
    // Need it so I can set ID
    [Activity(Label = "EditProfile")]
    [MvxViewFor(typeof(EditProfileFirstTimeViewModel))]
    public class EditProfileFirstTimeView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EditProfile);
        }
    }



}