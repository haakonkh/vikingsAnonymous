using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.Windows.Input;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels
{
    public class EditProfileFirstTimeViewModel : MvxViewModel
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
                if (age != value)
                {
                    SetProperty(ref age, value);
                }
            }
        }

        public EditProfileFirstTimeViewModel(IDatabase database)
        {
            this.database = database;
            SaveProfileCommand = new MvxCommand(()=>
            {
                SaveUserChanges(new MyTable()
                {
                    Name = Name,
                    Age = Age,
                    Weight = Weight,
                    Height = Height,
                    UserId = GetGeneratedUserId()
                });
            });
        }

        public async void SaveUserChanges(MyTable userinfo)
        {
            var x = await database.InsertTableRow(userinfo);
            ShowViewModel<FirstViewModel>(new {userid = userinfo.UserId});
            Close(this);
        }

        public string GetGeneratedUserId()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            string GS = Convert.ToBase64String(g.ToByteArray());
            GS = GuidString.Replace("=", "");
            GS = GuidString.Replace("+", "");

            string NGS = Convert.ToBase64String(g.ToByteArray());
            NGS = GuidString.Replace("=", "");
            NGS = GuidString.Replace("+", "");
            return GuidString + GS + NGS;
        }


    }
}
