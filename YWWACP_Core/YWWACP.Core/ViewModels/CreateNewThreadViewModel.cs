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
        private ISqlite sqlite;
        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        private string title;
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

        public CreateNewThreadViewModel(ISqlite sqlite)
        {
            sqlite = this.sqlite;

            SubmitCommand = new MvxCommand(() =>
            {
                AddThread(new Threads
                {
                    Title = Title,
                    Category = Category,
                    Content = Content,
                    CommentsID = 1,
                    UserID = 1
                });

            });
            GoBackCommand = new MvxCommand(() => ShowViewModel<CommunityViewModel>());

        }

        public void AddThread(Threads thread)
        {
            var database = new DatabaseTables(sqlite);
           // var azuredatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            
            if (!database.CheckIfThreadExists(thread))
            {
                database.InsertThread(thread);
            }
            
        }

        
    }
}
