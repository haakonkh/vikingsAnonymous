using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.Models
{
    public class Meal
    {
        private IDatabase database;
        public string MealId { get; set; }
        public string MealTitle { get; set; }
        public string MealSummary { get; set; }
        public string Ingredients { get; set; }
        public string Approach { get; set; }
        public string Time { get; set; }
        public string MealID { get; set; }
        public Meal() { }

        public Meal(string id, string title, string summary, string ingredients, string approach )
        {
            MealId = id;
            MealTitle = title;
            MealSummary = summary;
            Ingredients = ingredients;
            Approach = approach;

        }
        public Meal(string id, string title, string summary, string ingredients, string approach, string time)
        {
            MealId = id;
            MealTitle = title;
            MealSummary = summary;
            Ingredients = ingredients;
            Approach = approach;
            Time = time;
        }


    }
}
