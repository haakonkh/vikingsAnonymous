using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using YWWACP.Core.Interfaces;
using OxyPlot;
using OxyPlot.Axes;
using System;
using YWWACP.Core.ViewModels.Diary;
using System.Collections.ObjectModel;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class GraphViewModel : MvxViewModel
    {
        // Everyone should include these commands on their pages
        public ICommand OpenCommunityCommand { get; set; }
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenRecipesCommand { get; set; }
        public ICommand OpenDiaryCommand { get; set; }
        public ICommand OpenHomeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }

        private readonly IDatabase database;

        public ICommand GraphShow { get; set; }


        private ObservableCollection<Goal> goals = new ObservableCollection<Goal>();
        public ObservableCollection<Goal> Goals
        {
            get { return goals; }
            set { SetProperty(ref goals, value); }
        }

        private string userId;
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }
       // private string connection;

       
        public GraphViewModel(IDatabase database)
        {
              this.database = database;

            // THESE COMMANDS MUST EVERYONE IMPLEMENT IN THEIR CONSTRUCTORS.
            // I HAVE NOT COMMENTED OUT DIARY BECAUSE THAT DOES NOT EXIST AT THIS POINT.
            // COMMUNITY IS COMMENTED OUT BECAUSE THIS IS THE COMMUNITY VIEW AND IT MAKES ABSOULTE NO SENS TO NAVIGATE TO THE VIEW THAT YOU ARE IN
            // MAKE SURE YOU DO THE SAME
            OpenHealthPlanCommand = new MvxCommand(() =>
            {
                ShowViewModel<HealthPlanViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenDiaryCommand = new MvxCommand(() =>
            {
                ShowViewModel<DiaryViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenHomeCommand = new MvxCommand(() =>
            {
                ShowViewModel<FirstViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenRecipesCommand = new MvxCommand(() =>
            {
                ShowViewModel<RecipeViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenExerciseCommand = new MvxCommand(() =>
            {
                ShowViewModel<ExerciseViewModel>(new { userid = UserId });
                Close(this);
            });
            OpenCommunityCommand = new MvxCommand(() =>
            {
                ShowViewModel<CommunityViewModel>();
                Close(this);
            });

        }
        
        public void Init(string userid)
        {
            UserId = userid;
        }

        public void OnResume()
        {
            GetGoals();
            UpdateGraph();
        }


        //private void GeneratePlotPoints()
        //{
        //    var xAxis = new DateTimeAxis
        //    {
        //        Position = AxisPosition.Bottom,
        //        StringFormat = "dd/MM",
        //        Title = "End of week",

        //        IntervalLength = 75,
        //        MinorIntervalType = DateTimeIntervalType.Days,
        //        IntervalType = DateTimeIntervalType.Days,
        //        MajorGridlineStyle = LineStyle.Solid,
        //        MinorGridlineStyle = LineStyle.None,

        //    };

        //    //Author: Student 9787283, Student Kristoffer Helgesen
        //    var plotModel = new PlotModel { Title = "Your progression" };

        //    //(new LinearAxis { Position = AxisPosition.Bottom });

        //    plotModel.Axes.Add(xAxis);
        //    plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Maximum = 10, Minimum = 0 });

        //    var series1 = new OxyPlot.Series.LineSeries
        //    {
        //        MarkerType = MarkerType.Circle,
        //        MarkerSize = 4,
        //        MarkerStroke = OxyColors.White
        //    };
        //    //The first datapoint section is ment to set the day
        //    //The second datapoint is ment to set the value of the exercise based on a value of the day.

        //    DateTime tid = DateTime.Now;

        //    var x = DateTimeAxis.ToDouble(DateTime.Now);

        //    //The different points on the graph 
        //    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now), 4));
        //    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(+5)), 4));
        //    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(+10)), 5));
        //    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(+15)), 6));
        //    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(DateTime.Now.AddDays(+20)), 7));

        //    plotModel.Series.Add(series1);

        //    //  return plotModel;
        //    MyModel = plotModel;

        //}

        PlotModel _myModel;
        public PlotModel MyModel
        {
            get { return _myModel; }
            set { SetProperty(ref _myModel, value); }
        }

        public async void GetGoals()
        {
            var goals = await database.GetTable();
            Goals.Clear();
            foreach(var goal in goals)
            {
                if(goal.UserId == UserId && goal.GoalContent != null && goal.GoalDate == DateTime.Now.Date.ToString())
                {
                    Goals.Add(new Models.Goal(goal.GoalId, goal.GoalContent, goal.GoalDate, goal.GoalSatisfaction));
                    break;
                }
            }
            RaisePropertyChanged(() => Goals);
        }

        public async void UpdateGraph()
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


            var graphDetails = await database.GetTable();

            foreach(var graphDetail in graphDetails)
            {
                var check = graphDetail.GoalDate;
                if(graphDetail.UserId == UserId && graphDetail.GoalSatisfaction != 0.0)
                {
                    DateTime dt = Convert.ToDateTime(graphDetail.GoalDate);
                    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt), graphDetail.GoalSatisfaction));
                }
            }
            plotModel.Series.Add(series1);

            //  return plotModel;
            MyModel = plotModel;
            RaisePropertyChanged(() => MyModel);

        }
    }
}
