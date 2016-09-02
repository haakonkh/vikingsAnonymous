using System;
using Android.App;
using Android.OS;
using Android.Widget;

namespace YWWACP
{
    [Activity(Label = "Health Plan")]
    internal class HealthPlanActivity: Activity
    {
        private Button btnAddPlan;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the view from the "health plan" layout
            SetContentView(Resource.Layout.HealthPlan);

            // Connects to buttons
            btnAddPlan = FindViewById<Button>(Resource.Id.btnAddPlan);

            btnAddPlan.Click += btnAddPlan_Click;


        }

        private void btnAddPlan_Click(object sender, EventArgs e)
        {
            //pull up dialog
            FragmentTransaction transaction = FragmentManager.BeginTransaction();
            dialog_ChooseHealthPlan dialog = new dialog_ChooseHealthPlan();
            dialog.Show(transaction,"dialog fragment");
        }
    }
}