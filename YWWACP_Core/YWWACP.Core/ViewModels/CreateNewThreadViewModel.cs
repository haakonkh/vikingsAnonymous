using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
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
using YWWACP.Core.ViewModels;

namespace YWWACP.Core.ViewModels
{
    public class CreateNewThreadViewModel : MvxViewModel
    {
        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
        private string title;
        private CommunityViewModel cvm = new CommunityViewModel();


        public string Title
        {
            get { return title; }
            set {
                if(value != null)
                {
                    SetProperty(ref title, value);
                }
            }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set { if (value != null)
                {
                    SetProperty(ref category, value);
                }
            }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set {
            
                if (content != null)
                {
                    SetProperty(ref content, value);
                }
             }
        }
        public ObservableCollection<NewDiscussionThread> newThreads = new ObservableCollection<NewDiscussionThread>();
        public ObservableCollection<NewDiscussionThread> NewThreads
        {
            get { return newThreads; }
            set { SetProperty(ref newThreads, value); }

        }

        public CreateNewThreadViewModel()
        {

            SubmitCommand = new MvxCommand(() =>
            {
                AddThread(new NewDiscussionThread(Title, Category, Content));
                RaisePropertyChanged(() => NewThreads);
            });
            GoBackCommand = new MvxCommand(() => ShowViewModel<CommunityViewModel>());

        }

        public void AddThread(NewDiscussionThread thread)
        {
            thread.Content = "HEI";            thread.Category = " MAT";            thread.Title = "EHOHEHE";
            NewThreads.Add(thread);      
        }


        //private ISqlite sqlite;
        //private IDialogService dialog;
        //private ObservableCollection<Threads> threads;

        //public ObservableCollection<Threads> Threads
        //{
        //    get { return threads; }
        //    set { SetProperty(ref threads, value); }
        //}

        //private string title;

        //public string Title
        //{       
        //    get { return title; }
        //    set { SetProperty(ref title, value); }
        //}

        //private string category;

        //public string Category
        //{
        //    get { return category; }
        //    set { SetProperty(ref category, value); }
        //}

        //private string content;

        //public string Content
        //{
        //    get { return content; }
        //    set { SetProperty(ref content, value); }
        //}

        //public ICommand SubmitCommand { get; private set; }

        //public CreateNewThreadViewModel(ISqlite sqlite, IDialogService dialog)
        //{
        //    this.sqlite = sqlite;
        //    this.dialog = dialog;
        //    Threads = new ObservableCollection<Threads>();
        //SubmitCommand = new MvxCommand<Threads>(currentThread =>
        //{
        //    CurrentThread(currentThread);
        //});
        //}

        //public async void CurrentThread(Threads currentThread)
        //{
        //    var azuredatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
        //    var database = new DatabaseTables(sqlite);

        //    if (!database.CheckIfThreadExists(currentThread))
        //    {

        //        database.InsertThread(currentThread);
        //        await azuredatabase.GetTable<Threads>().InsertAsync(new Threads
        //        {
        //            Title = currentThread.Title,
        //            Category = currentThread.Category,
        //            Content = currentThread.Content
        //    });
        //        Close(this);    
        //    }
        //    else
        //    {

        //        Close(this);
        //    }
        //}

    }
}
