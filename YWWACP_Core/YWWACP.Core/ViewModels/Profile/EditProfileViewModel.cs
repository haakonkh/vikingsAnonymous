﻿using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Profile
{
    // ## Name: Andreas Norstein | ## Student number: 9805061

    public class EditProfileViewModel : MvxViewModel
    {
        public ICommand SaveProfileCommand { get; set; }
        public IDatabase database;

        private string name;

        public string Name
        {
            get { return name; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref name, value);
                    RaisePropertyChanged(() => Name);

                }
            }
        }

        private string height;

        public string Height
        {
            get { return height; }
            set
            {
                if (height != value)
                {
                    SetProperty(ref height, value);
                    RaisePropertyChanged(() => Height);

                }
            }
        }

        private string weight;

        public string Weight
        {
            get { return weight; }
            set
            {
                if (weight != value)
                {
                    SetProperty(ref weight, value);
                    RaisePropertyChanged(() => Weight);

                }
            }
        }

        private string age;

        public string Age
        {
            get { return age; }
            set
            {
                if (age !=value)
                {
                    SetProperty(ref age, value);
                    RaisePropertyChanged(() => Age);
                }
            }
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value);}
        }


        public EditProfileViewModel(IDatabase database)
        {
            this.database = database;
            SaveProfileCommand = new MvxCommand(() =>
            {
                SaveUserChanges(new MyTable()
                {
                    Name = Name,
                    Age = Age,
                    Weight = Weight,
                    Height =  Height,
                    UserId = UserId
                });
            });

        }

        public void Init(string userid)
        {
            UserId = userid;
            FindCorretUser();
        }

        /// <summary>
        /// This method will delete the exisiting row for that user and 
        /// create a new one with updated information. The user ID will NOT be changed
        /// but the primary key for that user will be changed. 
        /// </summary>
        /// <param name="userinfo"></param>
        public async void SaveUserChanges(MyTable userinfo)
        {
            var users = await database.GetTable();
            foreach (var user in users)
            {

                if (user.UserId == UserId && user.ThreadID == null && user.DiaryEntry == null && user.ExerciseId == null &&
                    user.MealId == null && user.GoalContent == null)
                {
                    var u = user.UserId;
                    await database.DeleteTableRow(user.Id);
                    var x = await database.InsertTableRow(userinfo);
                    Close(this);
                }
            }
        }

        /// <summary>
        /// Fill textfields with userdetails
        /// </summary>
        private async void FindCorretUser()
        {
            var users = await database.GetTable();
            foreach (var user in users)
            {
                if (user.UserId == UserId && user.ThreadID == null && user.DiaryEntry == null && user.ExerciseId == null &&
                    user.MealId == null && user.GoalContent == null)
                {
                    Name = user.Name;
                    Height = user.Height;
                    Weight = user.Weight;
                    Age = user.Age;
                }
            }
        }
    }
}
