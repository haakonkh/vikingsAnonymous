using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
    public class NewRecipeThread
    {
        public string MealTitle { get; set; }

        public string MealId { get; set; }

        public string MealSummary { get; set; }
        

        public NewRecipeThread() { }
        public NewRecipeThread(string id, string title, string summary)
        {
            MealId = id;
            MealTitle = title;
            MealSummary = summary;
        }
    }
}
