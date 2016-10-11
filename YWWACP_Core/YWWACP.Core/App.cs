using Android.App;
using Android.Content;
using Android.OS;
using Android.Preferences;
using Android.Util;
using MvvmCross.Platform.IoC;

namespace YWWACP.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
       
       ISharedPreferences prefs = Application.Context.GetSharedPreferences("MyPrefsFile", FileCreationMode.Private);
       

    public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            if (prefs.GetBoolean("my_first_time", true))
            {
                //the app is being launched for first time, do something        
                Log.Debug("Comments", "First time");

                // first time task
                RegisterAppStart<ViewModels.EditProfileFirstTimeViewModel>();

                // record the fact that the app has been started at least once
                prefs.Edit().PutBoolean("my_first_time", false).Commit();
            }
            else
            {
                RegisterAppStart<ViewModels.FirstViewModel>();
            }


        }
    }
}
