using System;
using System.Windows.Input;
using Android.App;
using Android.Content;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.ViewModels.Community;
using YWWACP.Core.ViewModels.Diary;
using YWWACP.Core.ViewModels.Goal;
using YWWACP.Core.ViewModels.Profile;

namespace YWWACP.Core.ViewModels.ExerciseRecipe
{
    public class FirstViewModel
        : MvxViewModel
    {
        public IDatabase database;
        public ICommand OpenCommand { get; set; }
        public ICommand OpenProfileCommand { get; set; }
        public ICommand OpenRecipeCommand { get; set; }
        public ICommand OpenExerciseCommand { get; set; }
        public ICommand OpenDiaryCommand { get; set; }

        public ICommand DeleteEverythingCommand { get; set; }
        private readonly ISharedPreferences prefUserInfo = Application.Context.GetSharedPreferences("UserInfo", FileCreationMode.Private);
        private readonly ISharedPreferences prefAppOpend = Application.Context.GetSharedPreferences("MyPrefsFile", FileCreationMode.Private);
        public ICommand OpenHealthPlanCommand { get; set; }
        public ICommand OpenGraphCommand { get; set; }


        private string userId;

        public string UserId
        {
            get { return userId; }
            set { SetProperty(ref userId, value); }
        }

        public FirstViewModel(IDatabase database)
        {
            this.database = database;
            UserId = prefUserInfo.GetString("UserId", "");
            CalculateBmi();
   
            OpenHealthPlanCommand = new MvxCommand(() => ShowViewModel<HealthPlanViewModel>(new { userid = UserId }));
            OpenGraphCommand = new MvxCommand(() => ShowViewModel<GraphViewModel>(new { userid = UserId }));
            OpenExerciseCommand = new MvxCommand(() => ShowViewModel<CreateNewGViewModel>(new { userid = UserId }));
            OpenRecipeCommand = new MvxCommand(() => ShowViewModel<ListExercisesViewModel>(new {userid = UserId}));
            OpenProfileCommand = new MvxCommand(() => ShowViewModel<ProfileViewModel>(new {userid = UserId}));
            OpenCommand = new MvxCommand(() => ShowViewModel<CommunityViewModel>(new {userid = UserId}));
            OpenDiaryCommand = new MvxCommand(() => ShowViewModel<DiaryViewModel>(new { userid = UserId,DateIn = DateTime.MinValue }));


            DeleteEverythingCommand = new MvxCommand(() =>
            {
                DeleteEverything();
            });
        }

        //public string GenerateID()
        //{
        //    Guid g = Guid.NewGuid();
        //    string GuidString = Convert.ToBase64String(g.ToByteArray());
        //    GuidString = GuidString.Replace("=", "").Replace("+", "");

        //    string GS = Convert.ToBase64String(g.ToByteArray());
        //    GS = GuidString.Replace("=", "").Replace("+", "");
        //    return GuidString + GS;
        //}
        public async void DeleteEverything()
        {
            var threads = await database.GetTable();
            foreach (var thread in threads)
            {
                await database.DeleteTableRow(thread.Id);
            }
            ISharedPreferencesEditor editor1 = prefUserInfo.Edit();
            editor1.Clear();
            editor1.Apply();

            ISharedPreferencesEditor editor2 = prefAppOpend.Edit();
            editor2.Clear();
            editor2.Apply(); ;

        }


        public void OnResume()
        {
            CalculateBmi();
        }


        private string bmi;
        public string BMI
        {
            get { return bmi; }
            set
            {
                SetProperty(ref bmi, value);
                RaisePropertyChanged(() => BMI);
            }
        }

        private string healthStatus;

        public string HealthStatus { get { return healthStatus; } set { SetProperty(ref healthStatus, value); RaisePropertyChanged(() => HealthStatus); } }

        private async void CalculateBmi()
        {
            var profiles = await database.GetTable();

            foreach (var profile in profiles)
            {
                if (UserId == profile.UserId && profile.ThreadID == null && profile.CommentID == null &&
                    profile.GoalId == null && profile.ExerciseId == null && profile.MealId == null)
                {
                    
                    var whey = Convert.ToDouble(profile.Weight);
                    var heightCM = Convert.ToDouble(profile.Height);
                    var heightMeter = heightCM / 100;

                    var bmi = (whey / (heightMeter * heightMeter));
                    var b = bmi.ToString();
                    b = b.Substring(0, b.IndexOf('.') + 2);
                    BMI = b;
                    if (bmi < 18.5)
                    {
                        HealthStatus = "Eat more!";
                    }
                    else if (bmi < 25)
                    {
                        HealthStatus = "Perfect body!";
                    }
                    else if (bmi > 25 && bmi < 30)
                    {
                        HealthStatus = "Consider Weightloss";
                    }
                    else
                    {
                        HealthStatus = "See a doctor";
                    }
                    break;
                }
                

            }

        }



    }
}