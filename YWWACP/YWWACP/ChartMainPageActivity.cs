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
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Xamarin.Android;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace YWWACP
{

    [Activity(Label = "ChartActivity")]
    public class ChartMainPageActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.ChartMainPage);

            PlotView view = FindViewById<PlotView>(Resource.Id.plot_view);
            view.Model = CreatePlotModel();

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

            series1.Points.Add(new OxyPlot.DataPoint(0.0, 6.0));
            series1.Points.Add(new OxyPlot.DataPoint(1.4, 2.1));
            series1.Points.Add(new OxyPlot.DataPoint(2.0, 4.2));
            series1.Points.Add(new OxyPlot.DataPoint(3.3, 2.3));
            series1.Points.Add(new OxyPlot.DataPoint(4.7, 7.4));
            series1.Points.Add(new OxyPlot.DataPoint(6.0, 6.2));
            series1.Points.Add(new OxyPlot.DataPoint(8.9, 8.9));

            plotModel.Series.Add(series1);

            return plotModel;

        }
    }
}