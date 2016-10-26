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
    //    private Button btnGraph;
        private TextView textViewHR;
        private TextView textViewGoal;
        private TextView textViewCalories;


        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.FirstView);

            //Generates a plotview
            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
            view.Model = CreatePlotModel();

            //Text View Box
            textViewGoal = FindViewById<TextView>(Resource.Id.textViewGoal);
            textViewHR = FindViewById<TextView>(Resource.Id.textViewHR);
            textViewCalories = FindViewById<TextView>(Resource.Id.textViewCalories);
        }
        private PlotModel CreatePlotModel()
        {
         
            var xAxis = new DateTimeAxis
            {
                Position = AxisPosition.Bottom,
                StringFormat = "dd/MM",
                Title = "End of week",
              
                IntervalLength = 75,              
                MinorIntervalType = DateTimeIntervalType.Days,
                IntervalType = DateTimeIntervalType.Days,
                MajorGridlineStyle = LineStyle.Solid,
                MinorGridlineStyle = LineStyle.None,
               
            };
            
            //Author: Student 9787283, Student Kristoffer Helgesen
            var plotModel = new PlotModel { Title = "Your progression" };
        
            //(new LinearAxis { Position = AxisPosition.Bottom });
            
            plotModel.Axes.Add(xAxis); 
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

            var series1 = new OxyPlot.Series.LineSeries
            {
                MarkerType = MarkerType.Circle,
                MarkerSize = 4,
                MarkerStroke = OxyColors.White
            };
            //The first datapoint section is ment to set the day
            //The second datapoint is ment to set the value of the exercise based on a value of the day.

           DateTime tid = DateTime.Now;
    
            //The different points on the graph 
            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now), 4));
            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(+5)), 4));
            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(+10)), 5));
            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(+15)), 6));
            series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(+20)), 7));
         //   series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(+1.25)), 8));
            //    series1.Points.Add(new OxyPlot.DataPoint(0.0, 10.0));
            //     series1.Points.Add(new OxyPlot.DataPoint(1.0, 2.0));
            //      series1.Points.Add(new OxyPlot.DataPoint(2.0, 4.0));
            //       series1.Points.Add(new OxyPlot.DataPoint(3.0, 2.5));
            //        series1.Points.Add(new OxyPlot.DataPoint(4.0, 7.0));
            //         series1.Points.Add(new OxyPlot.DataPoint(5.0, 6.0));
            //           series1.Points.Add(new OxyPlot.DataPoint(6.0, 9.0));

            plotModel.Series.Add(series1);

            return plotModel;

        }
        protected override void OnResume()
        {
            var vm = (FirstViewModel)ViewModel;
            vm.OnResume();
            base.OnResume();
        }


    }

}
