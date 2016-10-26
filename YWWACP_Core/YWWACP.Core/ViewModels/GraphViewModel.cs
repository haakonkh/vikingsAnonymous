using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using YWWACP.Core.Interfaces;
using OxyPlot;
using OxyPlot.Axes;
using System;
using YWWACP.Core.ViewModels.Diary;
using System.Collections.ObjectModel;
using YWWACP.Core.Models;
using System.Collections.Generic;
using YWWACP.Core.ViewModels.Community;

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


        public ICommand OpenNewGoalCommand { get; set; }





        private readonly IDatabase database;

        public ICommand GraphShow { get; set; }


        private ObservableCollection<Goal> goals = new ObservableCollection<Goal>();
        public ObservableCollection<Goal> Goals
        {
            get { return goals; }
            set { SetProperty(ref goals, value); }
        }

        List<MyTable> onlyGoals = new List<MyTable>();


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

            OpenNewGoalCommand = new MvxCommand(() => ShowViewModel<NewGoalViewModel>(new { userid = UserId }));

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
                ShowViewModel<CreateNewGViewModel>(new { userid = UserId });
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
            UpdateGraph();
            GetGoals();

        }



        PlotModel _myModel;
        public PlotModel MyModel
        {
            get { return _myModel; }
            set { SetProperty(ref _myModel, value); }
        }

        public async void GetGoals()
        {
            var goals = await database.GetTable();
            var dateAndTime = DateTime.Now;
            var formated = dateAndTime.ToString("dd/MM/yyyy");
            Goals.Clear();

            foreach (var goal in goals)
            {
                if (goal.UserId == UserId && goal.GoalContent != null && goal.GoalDate.Trim() == DateTime.Now.Date.ToString("dd/MM/yyyy").Trim())
                {// goal.GoalSatisfaction.ToString()
                    if (goal.GoalSatisfaction < 1 )
                    {
                        Goals.Add(new Goal(goal.GoalId, goal.GoalContent, formated.Trim(), "Satisfaction: " + "Not set "));
                        break;
                    }
                    if (goal.GoalSatisfaction ==  1 || goal.GoalSatisfaction == 2 || goal.GoalSatisfaction == 3 ){
                        Goals.Add(new Goal(goal.GoalId, goal.GoalContent, formated.Trim(), "Satisfaction: " + "Bad"));
                        break;
                    }
                    if (goal.GoalSatisfaction == 4 || goal.GoalSatisfaction == 5 || goal.GoalSatisfaction == 6 ){
                        Goals.Add(new Goal(goal.GoalId, goal.GoalContent, formated.Trim(), "Satisfaction: " + "OK"));
                        break;
                    }
                    if (goal.GoalSatisfaction == 7 || goal.GoalSatisfaction == 8 || goal.GoalSatisfaction == 9 || goal.GoalSatisfaction == 10)
                    {
                        Goals.Add(new Goal(goal.GoalId, goal.GoalContent, formated.Trim(), "Satisfaction: " + "Great!"));
                        break;
                    }
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

            onlyGoals.Clear();


            foreach (var graphDetail in graphDetails)
            {
                var check = graphDetail.GoalDate;
                if (graphDetail.UserId == UserId && graphDetail.GoalSatisfaction != 0.0)
                {                
                    onlyGoals.Add(graphDetail);
                }
            }

            onlyGoals.Sort((x, y) => Convert.ToDateTime(x.GoalDate).CompareTo(Convert.ToDateTime(y.GoalDate)));

            foreach (var goal in onlyGoals)
            {
                if(goal.GoalSatisfaction != 0) {

             
                    DateTime dt = Convert.ToDateTime(goal.GoalDate);
                    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt), goal.GoalSatisfaction));
               }

            }

            plotModel.Series.Add(series1);
            //  return plotModel;
            MyModel = plotModel;
            RaisePropertyChanged(() => MyModel);
          
        }
          
    }
    
}
