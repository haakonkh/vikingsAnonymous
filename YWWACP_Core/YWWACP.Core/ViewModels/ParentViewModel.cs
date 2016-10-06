using MvvmCross.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YWWACP.Core.ViewModels
{
    public class ParentViewModel : MvxViewModel
    {
        readonly Type[] menuItemTypes =
        {
            typeof(CommunityViewModel)
        };

        public IEnumerable<string> MenuItems { get; private set; }
            = new[] { "Community" };

        public void ShowDefaultMenuItem()
        {
            NavigateTo(0);
        }
        public void NavigateTo(int position)
        {
            ShowViewModel(menuItemTypes[position]);
        }
    }

    public class MenuItem : Tuple<string, Type>
    {
        public MenuItem(string displayName, Type viewModelType) : base(displayName, viewModelType) { }

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
