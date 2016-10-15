using System.Collections.Generic;
using System.Reflection;
using Android.Content;
using YWWACP.Core;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Views;
using MvvmCross.Droid.Support.V7.Fragging.Presenter;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;
using YWWACP.Core.Database;
using YWWACP.Core.Interfaces;

namespace YWWACP
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new App();
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }

        protected override void InitializeFirstChance()
        {
            Mvx.LazyConstructAndRegisterSingleton<ISqlite, SQLiteDroid>();
            Mvx.LazyConstructAndRegisterSingleton<IDatabase, DatabaseTables>();
            base.InitializeFirstChance();
        }

        protected override IEnumerable<Assembly> AndroidViewAssemblies => new List<Assembly>(base.AndroidViewAssemblies)
        {
            typeof(global::Android.Support.V7.Widget.Toolbar).Assembly,
        };

        protected override IMvxAndroidViewPresenter CreateViewPresenter()
        {
            var mvxFragmentsPresenter = new MvxFragmentsPresenter(AndroidViewAssemblies);
            Mvx.RegisterSingleton<IMvxAndroidViewPresenter>(mvxFragmentsPresenter);
            return mvxFragmentsPresenter;
        }

    }
}
