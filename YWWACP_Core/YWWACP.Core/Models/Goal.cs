using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
    public class Goal
    {

        public string GoalId { get; set; }
        public string GoalContent { get; set; }
        public string GoalDate { get; set; }
        public double GoalSatisfaction { get; set; }


        public Goal() { }
        public Goal(string goalId, string goalContent, string goalDate, double goalSatisfaction)
        {
            GoalId = goalId;
            GoalContent = goalContent;
            GoalDate = goalDate;
            GoalSatisfaction = goalSatisfaction;
        }

    }
}
