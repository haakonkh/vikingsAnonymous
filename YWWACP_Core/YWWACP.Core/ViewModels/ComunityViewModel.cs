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
        public ICommand SelectThreadCommand { get; set; }
       

        private ObservableCollection<NewDiscussionThread> newThreads = new ObservableCollection<NewDiscussionThread>();

        public ObservableCollection<NewDiscussionThread> NewThreads
        {
            get { return newThreads; }
            set { SetProperty(ref newThreads, value); }
        }

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
            SelectThreadCommand = new MvxCommand<NewDiscussionThread>(thread => ShowViewModel<CommentsViewModel>(new {threadID = thread.ThreadID}));

            MyThreadsCommand = new MvxCommand(() =>
            {
                DeleteEverything();
            });
        }

        public void OnResume()
        {
            GetThreads();
        }

        public async void GetThreads()
        {
            var threads = await database.GetTable();
            //Threads.Clear();
            NewThreads.Clear();
            foreach (var thread in threads)
            {
                var c = thread.Content;

                    if (thread.Content != null)
                {
                    NewThreads.Insert(0, new NewDiscussionThread(thread.ThreadTitle, thread.Category , thread.Content, thread.ThreadID));
                }
            }

            RaisePropertyChanged(() => NewThreads);

        }

        public async void DeleteEverything()
        {
            var threads = await database.GetTable();
            NewThreads.Clear();
            foreach (var thread in threads)
            {
                await database.DeleteTableRow(thread.Id);

            }
            RaisePropertyChanged(() => NewThreads);
        }
    }

}
