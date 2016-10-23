using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Database;
using YWWACP;
using YWWACP.Core.Database;
using YWWACP.Service;

namespace YWWACP
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new YWWACP.Core.App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SQLiteDroid>();

            // Line below will give local database
            //Mvx.LazyConstructAndRegisterSingleton<IDatabase, DatabaseTables>();

            // Line below will give database synced with azure
            Mvx.LazyConstructAndRegisterSingleton<IDatabase, DatabaseAzure>();

            Mvx.LazyConstructAndRegisterSingleton<IToast, ToastService>();
            Mvx.LazyConstructAndRegisterSingleton<IDialogService, DialogService>();
            Mvx.LazyConstructAndRegisterSingleton<IAzureDatabase, AzureDatabase>();

            base.InitializeFirstChance();
        }
    }
}
