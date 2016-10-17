using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.Models
{
    public class Exercise
    {
        private IDatabase database;
        public string ExerciseId { get; set; }
        public string ExerciseTitle { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public string ExerciseSummary { get; set; }
        public Exercise() { }

        public Exercise(string id, string title, string summary, int set, int rep)
        {
            ExerciseId = id;
            ExerciseTitle = title;
            ExerciseSummary = summary;
            Sets = set;
            Reps = rep;
        }



    }
}
