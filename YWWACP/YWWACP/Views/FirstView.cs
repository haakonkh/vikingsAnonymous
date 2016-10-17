using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using System;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using MvvmCross.Core.ViewModels;
using OxyPlot.Axes;
using OxyPlot;
using OxyPlot.Xamarin.Android;
using YWWACP.Core.ViewModels;

////, Theme="@style/MyTheme"
namespace YWWACP.Views
{
    [Activity(Label = "YWWACP")]
    public class FirstView : MvxActivity
    {
        private Button btnDiary;
        //private Button btnProfile;
        //private Button btnRecipes;
        private Button btnHealthPlan;
        //private Button btnCommunity;
        //private Button btnExercise;
        private Button btnGraph;
        private TextView textViewHR;
        private TextView textViewGoal;
        private TextView textViewCalories;

        public static MobileServiceClient MobileService =
    new MobileServiceClient(
    "https://vikinganonymous.azurewebsites.net"
);
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            //Generates a plotview
            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
            view.Model = CreatePlotModel();

            // Get our button from the layout resource,
            // and attach an event to it
            btnDiary = FindViewById<Button>(Resource.Id.btnDiary);
           // btnProfile = FindViewById<Button>(Resource.Id.btnProfile);
           // btnRecipes = FindViewById<Button>(Resource.Id.btnRecipes);
            btnHealthPlan = FindViewById<Button>(Resource.Id.btnHealthPlan);
           // btnCommunity = FindViewById<Button>(Resource.Id.btnCommunity);

           // btnHealthPlan.Click += BtnHealthPlan_Click;
            //btnExercise = FindViewById<Button>(Resource.Id.btnExercise);
            //btnExercise = FindViewById<Button>(Resource.Id.btnExercise);

            btnGraph = FindViewById<Button>(Resource.Id.btnGraph);

            btnDiary.Click += DiaryButton_Click;
            //btnCommunity.Click += BtnCommunity_Click;
           // btnRecipes.Click += BtnRecipes_Click;
           // btnProfile.Click += BtnProfile_Click;
           // btnExercise.Click += BtnExercise_Click;
            btnGraph.Click += BtnGraph_Click;

            //Text View Box
            textViewGoal = FindViewById<TextView>(Resource.Id.textViewGoal);
            textViewHR = FindViewById<TextView>(Resource.Id.textViewHR);
            textViewCalories = FindViewById<TextView>(Resource.Id.textViewCalories);
        }
        private PlotModel CreatePlotModel()
        {
            var plotModel = new PlotModel { Title = "Your progression" };

            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Bottom });
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new OxyPlot.Series.LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };

            //The different points on the graph 
            series1.Points.Add(new OxyPlot.DataPoint(0.0, 10.0));
            series1.Points.Add(new OxyPlot.DataPoint(1.4, 2.1));
            series1.Points.Add(new OxyPlot.DataPoint(2.0, 4.2));
            series1.Points.Add(new OxyPlot.DataPoint(3.3, 2.3));
            series1.Points.Add(new OxyPlot.DataPoint(4.7, 7.4));
            series1.Points.Add(new OxyPlot.DataPoint(6.0, 6.2));
            series1.Points.Add(new OxyPlot.DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);

            return plotModel;

        }

        private void BtnGraph_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ChartMainPageActivity));
            StartActivity(intent);
        }

        /**private void BtnExercise_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ExerciseActivity));
            StartActivity(intent);
        }**/
        /**
        private void BtnProfile_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ProfileActivity));
            StartActivity(intent);
        }*/

       /** private void BtnRecipes_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(RecipesActivity));
            StartActivity(intent);
        } */

        /*
        // When Community button is clicked
        private void BtnCommunity_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(CommunityActivity));
            StartActivity(intent);
        }*/



        //When Diary Button is clicked
        private void DiaryButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(DiaryActivity));
            StartActivity(intent);

        }

        /*private void BtnHealthPlan_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(HealthPlanActivity));
            StartActivity(intent);
        }*/
    }
    
}
