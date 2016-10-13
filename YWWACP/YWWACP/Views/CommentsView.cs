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
using System.Windows.Input;

namespace YWWACP.Views
{
    [MvxViewFor(typeof(CommentsViewModel))]
    [Activity(Label = "CommentsActivity")]
    public class CommentsView : MvxActivity
    {
        //private TextView btnDeleteThread;
        
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Comments);
            //btnDeleteThread.FindViewById<TextView>(Resource.Id.textViewDots);

            //btnDeleteThread.Click += BtnDeleteThread_Click;

        }

        //private void BtnDeleteThread_Click(object sender, EventArgs e)
        //{
        //    // Pull up the calendar dialog
        //    FragmentTransaction transaction = FragmentManager.BeginTransaction();
        //    DeleteThreadFragment deleteDialog = new DeleteThreadFragment();
        //    deleteDialog.Show(transaction, "dialog fragment");
        //}

        protected override void OnResume()
        {
            var vm = (CommentsViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }
      
    }

    //[Activity(Label = "yolo")]
    //[MvxViewFor(typeof(DeleteThreadViewModel))]
    //public class DeleteThreadFragment : DialogFragment
    //{
    //    public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
    //    {
    //        base.OnCreateView(inflater, container, savedInstanceState);
    //        // Needs to be changed to the acutally dialog window.
    //        // Not created
    //        var view = inflater.Inflate(Resource.Layout.Dialog_DeleteThread, container, false);

    //        return view;
    //    }
    //}
}