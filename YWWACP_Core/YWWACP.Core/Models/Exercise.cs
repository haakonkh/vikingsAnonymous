using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android;
using Android.Graphics.Drawables;
using Android.Media;
using YWWACP.Core.Interfaces;


namespace YWWACP.Core.Models
{
    public class Exercise
    {
        public string Title { get; set; }
		public string ExerciseSummary { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public string Time { get; set; }
        public string ExerciseID { get; set; }

        public Exercise() { }

        public Exercise(string title, string summary, int sets, int reps, string time,string exerciseID)
        {
            Title = title;
            ExerciseSummary = summary;
            Sets = sets;
            Reps = reps;
            Time = time;
            ExerciseID = exerciseID;
        }

        public Exercise(string id, string title, string summary, int set, int rep)
        {
            ExerciseID = id;
            Title = title;
            ExerciseSummary = summary;
            Sets = set;
            Reps = rep;
        }

    }
}
