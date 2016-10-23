using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Profile
{
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
                }
            }
        }
        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
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
    }
}
