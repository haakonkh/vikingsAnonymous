using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.ViewModels.Profile
{
    public class ProfileViewModel : MvxViewModel
    {
        public ICommand EditProfileCommand { get; set; }
        public readonly IDatabase database;

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
            get { return height;}
            set
            {
                if (value != null)
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
                if (value != null)
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
                if (value != null)
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


        public ProfileViewModel(IDatabase database)
        {
            this.database = database;
            EditProfileCommand = new MvxCommand(() => ShowViewModel<EditProfileViewModel>(new {userid = UserId}));
            
        }

        public void Init(string userid)
        {
            UserId = userid;
        }

        public void OnResume()
        {
            SetProfileProperties();
        }

        public async void SetProfileProperties()
        {
            setAge();
            setHeight();
            setWeight();
            var loadProfile = await database.GetTable();
            foreach (var profile in loadProfile)
            {
                if (UserId == profile.UserId && profile.ThreadID == null && profile.CommentID == null && profile.GoalId == null && profile.ExerciseId == null && profile.MealId == null)
                {
                    Name = profile.Name;
                    break;
                }
            }
            RaisePropertyChanged(() => Name);

        }

        private async void setAge()
        {
            var loadProfile = await database.GetTable();
            foreach (var profile in loadProfile)
            {
                if (UserId == profile.UserId && profile.ThreadID == null && profile.CommentID == null && profile.GoalId == null && profile.ExerciseId == null && profile.MealId == null)
                {
                    Age = profile.Age;
                    break;
                }
            }
            RaisePropertyChanged(() => Age);
        }

        private async void setHeight()
        {
            var loadProfile = await database.GetTable();
            foreach (var profile in loadProfile)
            {
                if (UserId == profile.UserId && profile.ThreadID == null && profile.CommentID == null && profile.GoalId == null && profile.ExerciseId == null && profile.MealId == null)
                {
                    Height = profile.Height;
                    break;
                }
            }
            RaisePropertyChanged(() => Height);
        }
        private async void setWeight()
        {
            var loadProfile = await database.GetTable();
            foreach (var profile in loadProfile)
            {
                if (UserId == profile.UserId && profile.ThreadID == null && profile.CommentID == null && profile.GoalId == null && profile.ExerciseId == null && profile.MealId == null)
                {
                    Weight = profile.Weight;
                    break;
                }
            }
            RaisePropertyChanged(() => Weight);


        }





    }
}
