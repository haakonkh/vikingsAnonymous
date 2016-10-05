using MvvmCross.Core.ViewModels;
using System;
using MvvmCross.Platform;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using YWWACP.Core.Database;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using SQLite.Net;


namespace YWWACP.Core.ViewModels
{
   public class CommunityViewModel : MvxViewModel
    {

        private DatabaseTables database;
        public ICommand AddNewThreadCommand { get; set; }
        public ICommand MyThreadsCommand { get; set; }
        public ICommand SelectedThreadCommad { get; set; }
        //List<Threads> threads = new List<Threads>();
        //DatabaseTables database;
        //private ISqlite sqlite;
        private ObservableCollection<Threads> threads;
        public ObservableCollection<Threads> Threads
        {
            get { return threads; }
            set { SetProperty(ref threads, value); }

        }

        public CommunityViewModel(ISqlite sqlite)
        {
            database = new DatabaseTables(sqlite);
            //database = new DatabaseTables(sqlite);
            AddNewThreadCommand = new MvxCommand(() =>ShowViewModel<CreateNewThreadViewModel>());
                
        }

        public void OnResume()
        {
            GetThreads();
        }

        public void GetThreads()
        {
            var threads = database.GetThreads();

            Threads.Clear();
            foreach (var thread in threads)
            {
                Threads.Add(thread);
            }
            
            RaisePropertyChanged(() => Threads);

        }
    }
    
}
