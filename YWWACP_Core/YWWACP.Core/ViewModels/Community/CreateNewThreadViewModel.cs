﻿using System;
using System.Collections.Generic;
using System.Windows.Input;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Community
{
    // ## Name: Andreas Norstein | ## Student number: 9805061

    public class CreateNewThreadViewModel : MvxViewModel
    {
        private IDatabase database;
        public ICommand SubmitCommand { get; set; }

        public ICommand CancelCommand
        {
            get { return new MvxCommand(() => Close(this)); }
        }

        public ICommand GoBackCommand { get; set; }


        private List<Item> categories_array = new List<Item>()
        {
            new Item("Food"),
            new Item("Exercises"),
            new Item("ChitChat"),
            new Item("Random")
        };

        public List<Item> CategoriesArray
        {
            get { return categories_array; }
            set
            {
                categories_array = value;
                RaisePropertyChanged(() => CategoriesArray);
            }
        }

        private Item selectedItem = new Item("Three");

        public Item SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value;
                RaisePropertyChanged(() => SelectedItem); }

        }


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

        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public CreateNewThreadViewModel(IDatabase database)
        {
            this.database = database;
            var t = new MyTable();
            SubmitCommand = new MvxCommand(() =>
            {
                AddThread(new MyTable()
                {
                    ThreadTitle = Title.Trim(),
                    Category = SelectedItem.Caption,
                    Content = Content.Trim(),
                    ThreadID = GetGeneratedThreadId(),
                    UserId = UserId

                });
            });
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public async void AddThread(MyTable thread)
        {
            if (String.IsNullOrEmpty(thread.ThreadTitle))
            {
                Mvx.Resolve<IToast>().Show("OPS you forgot the title");
            }
            else if (String.IsNullOrEmpty(thread.Content))
            {
                Mvx.Resolve<IToast>().Show("OPS you forgot to fill out your post");
            }


            if (!String.IsNullOrEmpty(thread.Content) && !String.IsNullOrEmpty(thread.ThreadTitle))
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

    public class Item
    {
        private DateTime dateTime;

        public Item(string caption)
        {
            Caption = caption;
        }

        public Item(DateTime dateTime)
        {
            this.dateTime = dateTime;
        }

        public string Caption { get; private set; }

        public override string ToString()
        {
            return Caption;
        }

        public override bool Equals(object obj)
        {
            var rhs = obj as Item;
            if (rhs == null)
                return false;
            return rhs.Caption == Caption;
        }

        public override int GetHashCode()
        {
            if (Caption == null)
                return 0;
            return Caption.GetHashCode();
        }

    }
}
