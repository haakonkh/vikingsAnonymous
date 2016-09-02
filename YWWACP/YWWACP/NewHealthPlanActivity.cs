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
    [Activity(Label = "Add new health plan")]
    public class NewHealthPlanActivity: Activity
    {
        private Spinner MondayActivities;
        private Spinner MondayFood;

        private Spinner TuesdayActivities;
        private Spinner TuesdayFood;

        private Spinner WednesdayActivities;
        private Spinner WednesdayFood;

        private Spinner ThursdayActivities;
        private Spinner ThursdayFood;

        private Spinner FridayActivities;
        private Spinner FridayFood;

        private Spinner SaturdayActivities;
        private Spinner SaturdayFood;

        private Spinner SundayActivities;
        private Spinner SundayFood;

        private Button Done;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set the view from the "new health plan" layout
            SetContentView(Resource.Layout.NewHealthPlan);

            MondayActivities = FindViewById<Spinner>(Resource.Id.spinnerActivitiesMonday);
            MondayFood = FindViewById<Spinner>(Resource.Id.spinnerFoodMonday);

            TuesdayActivities = FindViewById<Spinner>(Resource.Id.spinnerActivitiesTuesday);
            TuesdayFood = FindViewById<Spinner>(Resource.Id.spinnerFoodTuesday);

            WednesdayActivities = FindViewById<Spinner>(Resource.Id.spinnerActivitiesWednesday);
            WednesdayFood = FindViewById<Spinner>(Resource.Id.spinnerFoodWednesday);

            ThursdayActivities = FindViewById<Spinner>(Resource.Id.spinnerActivitiesThursday);
            ThursdayFood = FindViewById<Spinner>(Resource.Id.spinnerFoodThursday);

            FridayActivities = FindViewById<Spinner>(Resource.Id.spinnerActivitiesFriday);
            FridayFood = FindViewById<Spinner>(Resource.Id.spinnerFoodFriday);

            SaturdayActivities = FindViewById<Spinner>(Resource.Id.spinnerActivitiesSaturday);
            SaturdayFood = FindViewById<Spinner>(Resource.Id.spinnerFoodSaturday);

            SundayActivities = FindViewById<Spinner>(Resource.Id.spinnerActivitiesSunday);
            SundayFood = FindViewById<Spinner>(Resource.Id.spinnerFoodSunday);

            Spinner[] actSpinners =
            {
                MondayActivities,TuesdayActivities,WednesdayActivities,ThursdayActivities,FridayActivities
                ,SaturdayActivities,SundayActivities
            };
            Spinner[] foodSpinners =
            {
                MondayFood, TuesdayFood, WednesdayFood, ThursdayFood, FridayFood, SaturdayFood, SundayFood
            };

            for(int i=0; i< actSpinners.Length; i++)
            {
                var actAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.categories_activities, Android.Resource.Layout.SimpleSpinnerItem);
                actAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                actSpinners[i].Adapter = actAdapter;

                var foodAdapter = ArrayAdapter.CreateFromResource(this, Resource.Array.categories_food, Android.Resource.Layout.SimpleSpinnerItem);
                foodAdapter.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
                foodSpinners[i].Adapter = foodAdapter;
            }

            Done = FindViewById<Button>(Resource.Id.btnDone);

            Done.Click += Done_Click;

        }

        private void Done_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}