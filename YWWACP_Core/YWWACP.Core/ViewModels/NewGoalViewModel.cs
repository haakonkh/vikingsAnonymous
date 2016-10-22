using Android.App;
using Android.OS;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
   public class NewGoalViewModel : MvxViewModel
    {

        public ICommand SetNewGoalCommand { get; set; }
        //Get set. For NewGoal
        private string goalContent;
        public string GoalContent
        {
            get { return goalContent; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref goalContent, value);
                }
            }
        }
        /*       private string goalDate;
               public string GoalDate
               {
                   get { return goalDate; }
                   set
                   {
                       if (value != null)
                       {
                           SetProperty(ref goalDate, value);
                       }
                   }
               }  */

        
        private List<Item>goals_array = new List<Item>()
        {

          new Item(DateTime.Now.DayOfWeek  + " - " + DateTime.Now.Date.ToString("dd/MM/yyyy")),
          new Item(DateTime.Now.AddDays(+1).DayOfWeek + " - " + DateTime.Now.Date.AddDays(+1).ToString("dd/MM/yyyy")),
          new Item(DateTime.Now.AddDays(+2).DayOfWeek + " - " + DateTime.Now.Date.AddDays(+2).ToString("dd/MM/yyyy")),
          new Item(DateTime.Now.AddDays(+3).DayOfWeek + " - " + DateTime.Now.Date.AddDays(+3).ToString("dd/MM/yyyy")),
          new Item(DateTime.Now.AddDays(+4).DayOfWeek + " - " + DateTime.Now.Date.AddDays(+4).ToString("dd/MM/yyyy")),
          new Item(DateTime.Now.AddDays(+5).DayOfWeek + " - " + DateTime.Now.Date.AddDays(+5).ToString("dd/MM/yyyy")),
          new Item(DateTime.Now.AddDays(+6).DayOfWeek + " - " + DateTime.Now.Date.AddDays(+6).ToString("dd/MM/yyyy")),

        };

        private Item selectedGoal = new Item("Three");

        public Item SelectedGoal
        {
            get { return selectedGoal; }
            set
            {
                selectedGoal = value;
                RaisePropertyChanged(() => SelectedGoal);
            }

        }

        public List<Item> GoalsArray
        {
            get { return goals_array; }
            set
            {
                goals_array = value;
                RaisePropertyChanged(() => GoalsArray);
            }
        }
        private double goalSatisfaction;
        public double GoalSatisfaction
        {
            get { return goalSatisfaction; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref goalSatisfaction, value);
                }
            }
        }
        private string userId;
        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        private readonly IDatabase database;
        public NewGoalViewModel(IDatabase database)
        {
            
            
            this.database = database;
            var t = new MyTable();
          SetNewGoalCommand = new MvxCommand(() =>
            {
                string[] x = SelectedGoal.Caption.Split('-');
                if (GoalSatisfaction <= 10 && GoalSatisfaction !=0)
                {

                    if (GoalContent != null)
                    {
                        AddGoal(new MyTable()
                        {
                            GoalContent = goalContent,
                            GoalDate = SelectedGoal.Caption.Split('-')[1].Trim(),
                            GoalSatisfaction = goalSatisfaction,
                            GoalId = GetGeneratedGoalId(),
                            UserId = UserId

                        });
                    }
                    else { 
                    Mvx.Resolve<IToast>().Show("Goal content inst filled out ");
                    }
                }
                else {
                    Mvx.Resolve<IToast>().Show("Your goal satisfactionmust be within 1-10");                   
                }
            });  
        }

     
        public void Init(string userid)
        {
            UserId = userid;
        }
        public async void AddGoal(MyTable newgoal)
        {
            var goals = await database.GetTable();
            foreach (var goal in goals)
            {

                var i = goal.GoalDate;
                var p = SelectedGoal.Caption.Split('-')[1].Trim();
                var c = goal.GoalSatisfaction;
                var l = goal.GoalContent;

                if (goal.UserId == UserId && goal.ThreadID == null && goal.MealId == null && goal.ExerciseId == null &&
                    goal.CommentID == null && goal.GoalDate == SelectedGoal.Caption.Split('-')[1].Trim())
                {
                    var u = goal.UserId;
                    await database.DeleteTableRow(goal.Id);
                    var x = await database.InsertTableRow(newgoal);
                    Close(this);
                }
            }

            if (!String.IsNullOrEmpty(newgoal.GoalContent))
            {
                var x = await database.InsertTableRow(newgoal);
                Close(this);
            }
            Close(this);
        }

        public string GetGeneratedGoalId()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            string GS = Convert.ToBase64String(g.ToByteArray());
            GS = GuidString.Replace("=", "");
            GS = GuidString.Replace("+", "");
            return GuidString + GS;
        }


    }

}

