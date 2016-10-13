using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
    public class Exercise
    {
        public string Title { get; set; }
        public string Contents { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }
        public string Time { get; set; }
        public string ExerciseID { get; set; }

        public Exercise() { }

        public Exercise(string title, string contents, int sets, int reps, string time,string exerciseID)
        {
            Title = title;
            Contents = contents;
            Sets = sets;
            Reps = reps;
            Time = time;
            ExerciseID = exerciseID;
        }
    }
}
