using Android.Widget;
using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace YWWACP.Core.ViewModels
{
   public class TestThread : MvxViewModel
    {
        private string mTitle;
        private string mCategory;
        private string mContent;

        private Spinner dropdownCategories;
        public Spinner DropdownCategories
        {
            get { return dropdownCategories; }
        }

        private ObservableCollection<NewDiscussionThread> threads;
        public ObservableCollection<NewDiscussionThread> Threads
        {
            get { return threads; }
            set { SetProperty(ref threads, value);  }
        }

        public string Title
        {
            get { return mTitle; }
            set { SetProperty(ref mTitle, value); }
        }

        public string Category
        {
            get { return mCategory; }
            set {
                mCategory = DropdownCategories.SelectedItem.ToString();
                RaisePropertyChanged(() => dropdownCategories);
            }
        }

        public string Content
        {
            get { return mContent; }
            set { SetProperty( ref mContent, value); }
        }


        public ICommand SubmitCommand { get; set; }
        public ICommand SelectThreadCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public TestThread(string title, string category, string content)
        {
            Threads = new ObservableCollection<NewDiscussionThread>()
            {
                new NewDiscussionThread("Vegies or meet?", "Food", "What should I eat today, vegies or a good old beef?")
            };
            SubmitCommand = new MvxCommand(() =>
            {
                AddThread(new NewDiscussionThread(title, category, content));
                RaisePropertyChanged(() => Threads);
            });

            CancelCommand = new MvxCommand(() =>
            {

            });

            SelectThreadCommand = new MvxCommand<NewDiscussionThread>(thread =>
            {
                Title = thread.Title;
                Category = thread.Category;
                Content = thread.Content;
            });
           
        }

        public void AddThread(NewDiscussionThread thread)
        {
            if (thread.Title != null && thread.Category != null && thread.Content != null)
            {
                if(thread.Title.Trim() != string.Empty && thread.Category.Trim() != string.Empty && thread.Content.Trim() != string.Empty)
                {
                    threads.Insert(0, thread);
                }
                else
                {
                    Title = Title.Trim();
                    Category = Category.Trim();
                    Content = Content.Trim();
                }
            }
        }
    }
}

