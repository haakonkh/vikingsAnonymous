using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Android.Widget;
using Android.Content;
using System;

namespace YWWACP.Views
{
    [Activity(Label = "View for FirstViewModel")]
    public class FirstView : MvxActivity
    {
        private Button btnDiary;
        private Button btnProfile;
        private Button btnRecipes;
        private Button btnHealthPlan;
        private Button btnCommunity;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);
            btnDiary = FindViewById<Button>(Resource.Id.btnDiary);
            btnProfile = FindViewById<Button>(Resource.Id.btnProfile);
            btnRecipes = FindViewById<Button>(Resource.Id.btnRecipes);
            btnHealthPlan = FindViewById<Button>(Resource.Id.btnHealthPlan);
            btnCommunity = FindViewById<Button>(Resource.Id.btnCommunity);

            btnDiary.Click += DiaryButton_Click;
            btnCommunity.Click += BtnCommunity_Click;
            btnRecipes.Click += BtnRecipes_Click;
            btnProfile.Click += BtnProfile_Click;
        }

        private void BtnProfile_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ProfileActivity));
            StartActivity(intent);
        }

        private void BtnRecipes_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RecipesActivity));
            StartActivity(intent);
        }

        // When Community button is clicked
        private void BtnCommunity_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CommunityActivity));
            StartActivity(intent);
        }

        //When Diary Button is clicked
        private void DiaryButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(DiaryActivity));
            StartActivity(intent);

        }
    }
}
