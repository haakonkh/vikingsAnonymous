using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Support.V7.Fragging.Presenter;
using MvvmCross.Platform;

namespace YWWACP
{


    public class CustomFragmentsPresenter : MvxFragmentsPresenter
    {
        public interface IMvxFragmentHostEx : IMvxFragmentHost
        {
            void Close(IMvxViewModel viewModel);
            void ChangePresentation(MvxPresentationHint hint);
        }

        private IMvxNavigationSerializer _serializer;

        private IMvxNavigationSerializer Serializer
        {
            get
            {
                if (_serializer != null)
                    return _serializer;

                _serializer = Mvx.Resolve<IMvxNavigationSerializer>();
                return _serializer;
            }
        }

        public override void ChangePresentation(MvxPresentationHint hint)
        {
            if (hint != null)
            {
                var fragmentHost = Activity as IMvxFragmentHost as IMvxFragmentHostEx;
                if (fragmentHost != null)
                {
                    fragmentHost.ChangePresentation(hint);
                }
            }
            base.ChangePresentation(hint);
        }



        public CustomFragmentsPresenter(IEnumerable<Assembly> AndroidViewAssemblies) : base(AndroidViewAssemblies)
        {
        }
    }

}