using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace YWWACP
{
    [Activity(Label = "YWWACP", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        private Button btnDiary;
        private Button btnProfile;
        private Button btnRecipes;
        private Button btnHealthPlan;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

          

          



            // Get our button from the layout resource,
            // and attach an event to it
            btnDiary = FindViewById<Button>(Resource.Id.btnDiary);
            btnProfile = FindViewById<Button>(Resource.Id.btnProfile);
            btnRecipes = FindViewById<Button>(Resource.Id.btnRecipes);
            btnHealthPlan= FindViewById<Button>(Resource.Id.btnHealthPlan);


            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };

            btnDiary.Click += DiaryButton_Click;
            btnProfile.Click += BtnProfile_Click;
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ProfileActivity));
            StartActivity(intent);
        }

        private void DiaryButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(DiaryActivity));
            StartActivity(intent);

        }
    }
}

