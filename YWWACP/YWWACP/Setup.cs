using Android.Content;
using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Database;
using YWWACP;
using YWWACP.Core.Database;

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
            Mvx.LazyConstructAndRegisterSingleton<IDatabase, DatabaseTables>();
            Mvx.LazyConstructAndRegisterSingleton<IAzureDatabase, AzureDatabase>();

            base.InitializeFirstChance();
        }

    }
}
