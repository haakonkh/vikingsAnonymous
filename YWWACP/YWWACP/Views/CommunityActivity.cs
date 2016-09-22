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
using YWWACP.Core.ViewModels;
using MvvmCross.Core.Views;
using MvvmCross.Droid.Views;
using System.Windows.Input;

namespace YWWACP
{
    [MvxViewFor(typeof(CommunityViewModel))]
    [Activity(Label = "CommunityActivity")]
    public class CommunityActivity : MvxActivity
    {
       //private Button mNewThread;
       // private Button mMyThreads;
       //private ListView mListView;
       // private ListViewAdapter mAdapter;

        //private List<NewDiscussionThread> mItems;
        public ICommand NewThreadCommand { get; set; }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Community);
            NewThreadCommand = new MvxCommand(() =>
            {
                FragmentTransaction transaction = FragmentManager.BeginTransaction();
                Dialog_NewThread newThreadDialog = new Dialog_NewThread();
                newThreadDialog.Show(transaction, "dialog fragment");
            });


            /*
            // Connecting buttons to view
            mMyThreads = FindViewById<Button>(Resource.Id.btnMyThreads);



            mListView = FindViewById<ListView>(Resource.Id.listViewCommunity);
            mItems = new List<NewDiscussionThread>();


            mAdapter = new ListViewAdapter(this, mItems);
            mListView.Adapter = mAdapter;
            mNewThread = FindViewById<Button>(Resource.Id.btnNewThread);
            mNewThread.Click += MNewThread_Click;
    */
        }

        // When clicked, new thread will be created and and placed
        // below the buttons

            /*
        private void MNewThread_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            Dialog_NewThread newThreadDialog = new Dialog_NewThread();
            newThreadDialog.Show(transaction, "dialog fragment");

           // newThreadDialog.mOnSubmit += NewThreadDialog_mOnSubmit;
        }


        /*
        private void NewThreadDialog_mOnSubmit(object sender, OnSubmitThread e)
        {
           // mItems.Insert(0, new NewDiscussionThread{ Title = e.Title, Category = e.Category, Content = e.Content });
         }*/
    }
}
