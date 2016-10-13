using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.ViewModels.Health_Plan
{
    public class AddExerciseViewModel: MvxViewModel
    {
        public IDatabase database;

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }
        public AddExerciseViewModel(IDatabase database)
        {
            this.database = database;
            

        }
    }
}
