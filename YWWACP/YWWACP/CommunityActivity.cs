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
    [Activity(Label = "CommunityActivity")]
    public class CommunityActivity : Activity
    {
        private Button mNewThread;
        private Button mMyThreads;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Community);

            // Connecting buttons to view
            mNewThread = FindViewById<Button>(Resource.Id.btnNewThread);
            mMyThreads = FindViewById<Button>(Resource.Id.btnMyThreads);
            // Create your application here

            mNewThread.Click += MNewThread_Click;
        }

        // When clicked, new thread will be created and and placed 
        // below the buttons
  
        private void MNewThread_Click(object sender, EventArgs e)
        {
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_new_thread newThreadDialog = new dialog_new_thread(); 
            newThreadDialog.Show(transaction, "dialog fragment");
            
        }
    }
}