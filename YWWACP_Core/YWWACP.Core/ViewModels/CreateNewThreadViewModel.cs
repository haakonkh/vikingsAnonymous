
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Binding.ExtensionMethods;
using YWWACP.Core.Database;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;
using YWWACP.Core.ViewModels;

namespace YWWACP.Core.ViewModels
{
    public class CreateNewThreadViewModel : MvxViewModel
    {
        private IDatabase database;
        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand { get; set; }
        public ICommand GoBackCommand { get; set; }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref title, value);
                }
            }
        }

        private string category;

        public string Category
        {
            get { return category; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref category, value);
                }
            }
        }

        private string content;

        public string Content
        {
            get { return content; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref content, value);
                }
            }
        }

        public CreateNewThreadViewModel(IDatabase database)
        {
            this.database = database;

            SubmitCommand = new MvxCommand(() =>
            {
                AddThread(new MyTable
                {
                    ThreadTitle = Title,
                    Category = "FOOD",
                    Content = Content
                });
            });
        }

        public async void AddThread(MyTable thread)
        {
            //var data = new DatabaseTables();
            // var azuredatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            var x = await database.InsertTableRow(thread);
            ShowViewModel<CommunityViewModel>();


        }
    }
    }

