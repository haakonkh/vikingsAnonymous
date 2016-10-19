using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using YWWACP.Core.ViewModels.Health_Plan;

namespace YWWACP.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        readonly Type[] _menuItemTypes = {
            
            typeof(ProfileViewModel),
            typeof(CommunityViewModel),
            typeof(FirstViewModel)
        };

        public IEnumerable<string> MenuItems { get; private set; } = new[] { "Profile", "Community", "First"};

        public void ShowDefaultMenuItem()
        {
            NavigateTo(0);
        }

        public void NavigateTo(int position)
        {
            ShowViewModel(_menuItemTypes[position]);
        }
    }

    public class MenuItem : Tuple<string, Type>
    {
        public MenuItem(string displayName, Type viewModelType)
            : base(displayName, viewModelType)
        { }

        public string DisplayName
        {
            get { return Item1; }
        }

        public Type ViewModelType
        {
            get { return Item2; }
        }
    }

   
}