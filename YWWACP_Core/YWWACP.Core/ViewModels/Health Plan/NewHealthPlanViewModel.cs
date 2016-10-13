using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.ViewModels
{
    public class NewHealthPlanViewModel : MvxViewModel
    {

        public ICommand AddExerciseCommand { get; set; }
        public IDatabase database;

        public NewHealthPlanViewModel(IDatabase database)
        {

            this.database = database;

            AddExerciseCommand = new MvxCommand(() => ShowViewModel<NewHealthPlanViewModel>());

        }

    }
}
