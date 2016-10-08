
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
using Android.Widget;

namespace YWWACP.Core.ViewModels
{
    public class CreateNewThreadViewModel : MvxViewModel
    {
        private IDatabase database;
        public ICommand SubmitCommand { get; set; }
        public ICommand CancelCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }
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
            var t = new MyTable();
            SubmitCommand = new MvxCommand(() =>
            {
                AddThread( new MyTable()
                {
                ThreadTitle = Title,
                Category = Category,
                Content = Content,
                ThreadID = GetGeneratedThreadId()

                });
            });
        }

        public async void AddThread(MyTable thread)
        {
            // var azuredatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            if (thread.Content != "" || thread.Content != null)
            {
                var x = await database.InsertTableRow(thread);
                Close(this);
            }

       }

        public string GetGeneratedThreadId()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            string GS = Convert.ToBase64String(g.ToByteArray());
            GS = GuidString.Replace("=", "");
            GS = GuidString.Replace("+", "");
            return GuidString + GS;
        }
            
        
    }
 }

