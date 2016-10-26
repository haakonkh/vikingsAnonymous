using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
    public class DiaryEntry
    {
        public Meal Meal { get; set; }
        public Exercise Exercise { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }

        public DiaryEntry(){}

        public DiaryEntry(Meal meal, Exercise exercise, string type, string title)
        {
            Meal = meal;
            Exercise = exercise;
            Type = type;
            Title = title;
        }
    }
}
