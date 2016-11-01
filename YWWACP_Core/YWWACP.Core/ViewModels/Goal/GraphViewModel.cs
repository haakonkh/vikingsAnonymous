using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Android.App;
using Android.Content;
using MvvmCross.Core.ViewModels;
using OxyPlot;
using OxyPlot.Axes;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Diary;
using System.Globalization;

namespace YWWACP.Core.ViewModels.Goal
{
    public class GraphViewModel : MvxViewModel
    {
        public DayOfWeek DayOfWeek { get; }



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


        private readonly ISharedPreferences prefUserInfo = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
        private readonly ISharedPreferences prefAppOpend = Application.Context.GetSharedPreferences("MyPrefsFile", FileCreationMode.Private);

        private ObservableCollection<Models.Goal> goals = new ObservableCollection<Models.Goal>();
        public ObservableCollection<Models.Goal> Goals
        {
            get { return goals; }
            set { SetProperty(ref goals, value); }
        }

        List<MyTable> onlyGoals = new List<MyTable>();
        List<MyTable> onlySucs = new List<MyTable>();
        List<MyTable> onlySortedThisWeek = new List<MyTable>();


        private string userId;
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public GraphViewModel(IDatabase database)
        {


            this.database = database;
            UserId = prefUserInfo.GetString("UserId", "");
            UpdateGraph();
            GetGoals();
            CalculateBmi();
            CheckInstance();


            OpenNewGoalCommand = new MvxCommand(() => ShowViewModel<NewGoalViewModel>(new { userid = UserId }));

            // THESE COMMANDS MUST EVERYONE IMPLEMENT IN THEIR CONSTRUCTORS.
            // I HAVE NOT COMMENTED OUT DIARY BECAUSE THAT DOES NOT EXIST AT THIS POINT.
            // COMMUNITY IS COMMENTED OUT BECAUSE THIS IS THE COMMUNITY VIEW AND IT MAKES ABSOULTE NO SENS TO NAVIGATE TO THE VIEW THAT YOU ARE IN
            // MAKE SURE YOU DO THE SAME
            OpenHealthPlanCommand = new MvxCommand(() => { ShowViewModel<HealthPlanViewModel>(new { userid = UserId }); Close(this); });
            OpenDiaryCommand = new MvxCommand(() => { ShowViewModel<DiaryViewModel>(new { userid = UserId }); Close(this); });
            OpenHomeCommand = new MvxCommand(() => { ShowViewModel<FirstViewModel>(new { userid = UserId }); Close(this); });
            OpenRecipesCommand = new MvxCommand(() => { ShowViewModel<RecipeViewModel>(new { userid = UserId }); Close(this); });
            OpenExerciseCommand = new MvxCommand(() => { ShowViewModel<CreateNewGViewModel>(new { userid = UserId }); Close(this); });
            OpenCommunityCommand = new MvxCommand(() => { ShowViewModel<CommunityViewModel>(new { userid = UserId}); Close(this); });


        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public void OnResume()
        {
            UpdateGraph();
            GetGoals();
            CalculateBmi();
            CheckInstance();
        }

        PlotModel _myModel;
        public PlotModel MyModel
        {
            get { return _myModel; }
            set { SetProperty(ref _myModel, value); RaisePropertyChanged(() => MyModel); }
        }


        private string mSSucsessRate;
        public string MSSucsessRate
        {
            get { return mSSucsessRate; }
            set
            {
                SetProperty(ref mSSucsessRate, value);
                RaisePropertyChanged(() => MSSucsessRate);
            }
        }
        private string mSGoal;
        public string MSGoal
        {
            get { return mSGoal; }
            set
            {
                SetProperty(ref mSGoal, value);
                RaisePropertyChanged(() => MSGoal);
            }
        }

        public async void GetGoals()
        {
            int test = 0;
            int intUser = 0;
            var goals = await database.GetTable();
            var dateAndTime = DateTime.Now;
            var formated = dateAndTime.ToString("dd/MM/yyyy");
            Goals.Clear();

            foreach (var goal in goals)
            {

                if (goal.UserId == UserId && goal.GoalContent != null && goal.GoalDate.Trim() == DateTime.Now.Date.ToString("dd/MM/yyyy").Trim())
                {             
                                            
                                if (goal.GoalSatisfaction < 1)
                                {
                                test = 1;
                                Goals.Add(new Models.Goal(goal.GoalId, goal.GoalContent, formated.Trim(), "Satisfaction: " + "Not set "));
                          
                                break;
                                }
                                if (goal.GoalSatisfaction <= 3)
                                {
                                test = 1;
                                Goals.Add(new Models.Goal(goal.GoalId, goal.GoalContent, formated.Trim(), "Satisfaction: " + "Bad"));
                            
                                break;
                                }
                                if (goal.GoalSatisfaction <= 6)
                                {
                                test = 1;
                                Goals.Add(new Models.Goal(goal.GoalId, goal.GoalContent, formated.Trim(), "Satisfaction: " + "OK"));
                             
                                break;
                                }
                                if (goal.GoalSatisfaction > 6 && goal.GoalSatisfaction < 11)
                                {
                                test = 1;
                                Goals.Add(new Models.Goal(goal.GoalId, goal.GoalContent, formated.Trim(), "Satisfaction: " + "Great!"));
                               
                                break;
                         }                                                   
                     }
                RaisePropertyChanged(() => Goals);
            }
                    if (test == 0) {

                        Goals.Add(new Models.Goal(" ", "No goals today. Press +", "   ", "    "));

                    }
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
                if (graphDetail.UserId == UserId && graphDetail.GoalSatisfaction != 0.0)
                {
                    onlyGoals.Add(graphDetail);
                }
            }

            onlyGoals.Sort((x, y) => Convert.ToDateTime(x.GoalDate).CompareTo(Convert.ToDateTime(y.GoalDate)));

            foreach (var goal in onlyGoals)
            {
                if (Math.Abs(goal.GoalSatisfaction) > 0) {

                    DateTime dt = Convert.ToDateTime(goal.GoalDate);
                    series1.Points.Add(new DataPoint(DateTimeAxis.ToDouble(dt), goal.GoalSatisfaction));
                }
            }

            plotModel.Series.Add(series1);
            MyModel = plotModel;
            RaisePropertyChanged(() => MyModel);
            //CheckInstance();

        }
        //List<string> SatisfactionG = new List<string>();
        // var a = DateTime.DayOfWeek.Monday;

        private async void CheckInstance()
        {

            //  DateThisWeekStuff
            DateTime input = DateTime.Now;
            int delta = DayOfWeek.Monday - input.DayOfWeek;
            DateTime monday = input.AddDays(delta);

            //  MyDates
            DateTime DateModay = DateTime.Now.Date.AddDays(delta);
            string DateLast = DateTime.Now.Date.AddDays(delta + 6).ToString("dd");
           

            var table = await database.GetTable();

            onlySucs.Clear();

            foreach (var tableRow in table)
            {
                DateTime tableDate = Convert.ToDateTime(tableRow.GoalDate);
             
                if (tableRow.UserId == UserId)
                {
                    if (DateModay == tableDate || DateModay.AddDays(+1) == tableDate || DateModay.AddDays(+2) == tableDate || DateModay.AddDays(+3) == tableDate || DateModay.AddDays(+4) == tableDate || DateModay.AddDays(+5) == tableDate || DateModay.AddDays(+6) == tableDate)
                    {
                        onlySucs.Add(tableRow);
                    }
                }

                onlySucs.Sort((x, y) => x.GoalSatisfaction.CompareTo(y.GoalSatisfaction));

                //Shows the last satisfaction that was added if new added value is the same as previously added value 
                foreach (var sucs in onlySucs)
                {
                    MSSucsessRate = sucs.GoalContent;
                    MSGoal = sucs.GoalDate;
                }
            }
        }
        /// ######################################################################


        private string bmi;
        public string BMI
        {
            get { return bmi; }
            set
            {
                SetProperty(ref bmi, value);
                RaisePropertyChanged(() => BMI);
            }
        }

        private string healthStatus;

        public string HealthStatus { get { return healthStatus; } set { SetProperty(ref healthStatus, value); RaisePropertyChanged(() => HealthStatus); } }

        private async void CalculateBmi()
        {
            var profiles = await database.GetTable();

            foreach (var profile in profiles)
            {
                if (UserId == profile.UserId && profile.ThreadID == null && profile.CommentID == null &&
                    profile.GoalId == null && profile.ExerciseId == null && profile.MealId == null)
                {

                    var whey = Convert.ToDouble(profile.Weight);
                    var heightCM = Convert.ToDouble(profile.Height);
                    var heightMeter = heightCM / 100;

                    var bmi = (whey / (heightMeter * heightMeter));
                    var b = bmi.ToString();
                    b = b.Substring(0, b.IndexOf('.') + 2);
                    BMI = b;
                    if (bmi < 18.5)
                    {
                        HealthStatus = "Eat more!";
                    }
                    else if (bmi < 25)
                    {
                        HealthStatus = "Perfect body!";
                    }
                    else if (bmi > 25 && bmi < 30)
                    {
                        HealthStatus = "Consider Weightloss";
                    }
                    else
                    {
                        HealthStatus = "See a doctor";
                    }
                    break;
                }


            }

        }



      
    }
    
}
