using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.Models
{
    public class NewExerciseThread
    {
        public string ExerciseId { get; set; }

        public string ExerciseTitle { get; set; }

        public string ExerciseSummary{ get; set; }


        public NewExerciseThread() { }
        public NewExerciseThread(string id, string title, string summary)
        {
            ExerciseId = id;
            ExerciseTitle = title;
            ExerciseSummary = summary;
        }
    }
}
