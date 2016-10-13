using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Core.ViewModels
{
    public class HealthPlanViewModel : MvxViewModel
    {
        public ICommand OpenExerciseCommand { get; set; }
        public ICommand OpenMealCommand { get; set; }

        public IDatabase database;

        public HealthPlanViewModel(IDatabase database)
        {
            this.database = database;

            OpenExerciseCommand = new MvxCommand(() => ShowViewModel<HealthPlanExerciseViewModel>(new { userid = UserId }));
            //OpenMealCommand = new MvxCommand(() => ShowViewModel<NewHealthPlanViewModel>());


        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

    }
}
