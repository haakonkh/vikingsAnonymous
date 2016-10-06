using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YWWACP.Core.Database;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class CommunityViewModel : MvxViewModel
    {

        private readonly IDatabase database;
        public ICommand AddNewThreadCommand { get; set; }
        public ICommand MyThreadsCommand { get; set; }
        public ICommand SelectedThreadCommad { get; set; }
        //List<Threads> threads = new List<Threads>();
        //DatabaseTables database;
        //private ISqlite sqlite;
        private ObservableCollection<MyTable> threads = new ObservableCollection<MyTable>();
        public ObservableCollection<MyTable> Threads
        {
            get { return threads; }
            set { SetProperty(ref threads, value); }
        }

        public CommunityViewModel(IDatabase database)
        {
            this.database = database;
            AddNewThreadCommand = new MvxCommand(() => ShowViewModel<CreateNewThreadViewModel>());
        }

        public void OnResume()
        {
            GetThreads();
        }

        public async void GetThreads()
        {
            var threads = await database.GetTable();
            Threads.Clear();
            foreach (var thread in threads)
            {
                Threads.Add(thread);
                
            }

            RaisePropertyChanged(() => Threads);

        }
    }

}
