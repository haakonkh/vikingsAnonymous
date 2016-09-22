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

        public ICommand AddNewThreadCommand { get; set; }
        public ICommand MyThreadsCommand { get; set; }

        //List<Threads> threads = new List<Threads>();
        //DatabaseTables database;
        //private ISqlite sqlite;
        public ObservableCollection<NewDiscussionThread> newThreads;
        public ObservableCollection<NewDiscussionThread> NewThreads
        {
            get { return newThreads; }
            set { SetProperty(ref newThreads, value); }

        }

        public CommunityViewModel()
        {
            //database = new DatabaseTables(sqlite);
            AddNewThreadCommand = new MvxCommand(() =>ShowViewModel<CreateNewThreadViewModel>());
                
        }

        //public void OnResume()
        //{
        //    GetThreads();
        //}

        //public async void GetThreads()
        //{
        //    var azuredatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
        //    var azureresults = await azuredatabase.GetTable<Threads>().ToListAsync();
        //    var threads = database.GetThreads();

        //    NewThreads.Clear();
        //    foreach(var thread in threads)
        //    {
        //        NewThreads.Add(new NewDiscussionThread(thread.Title, thread.Category, thread.Content));
        //    }

        //}
    }
    
}
