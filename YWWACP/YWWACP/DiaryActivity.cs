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
    [Activity(Label = "DiaryActivity")]
    public class DiaryActivity : Activity
    {
        private Button mYesterdayBtn;
        private Button mTodayBtn;
        private Button mTomorrowBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the view from the "Diary" layout
            SetContentView(Resource.Layout.Diary);

            // Connects to buttons
            mYesterdayBtn = FindViewById<Button>(Resource.Id.btnYesterday);
            mTodayBtn = FindViewById<Button>(Resource.Id.btnToday);
            mTomorrowBtn = FindViewById<Button>(Resource.Id.btnTomorrow);

            mTodayBtn.Click += MTodayBtn_Click;
            
        }

        private void MTodayBtn_Click(object sender, EventArgs e)
        {
            // Pull up the calendar dialog
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_calendar calendarDialog = new dialog_calendar();
            calendarDialog.Show(transaction, "dialog fragment");




        }
    }
}