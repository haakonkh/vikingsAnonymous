using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Android;
using Android.App;
using Android.OS;
using Android.Views;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.ViewModels
{
    public class DeleteThreadViewModel : MvxViewModel
    {
        public ICommand DeleteThreadCommand { get; set; }
        private IDatabase database;

        private string threadId;

        public string ThreadId { get { return threadId; } set { SetProperty(ref threadId, value); } }

        public DeleteThreadViewModel(IDatabase database)
        {
            this.database = database;
            DeleteThreadCommand = new MvxCommand(() =>
            {
                DeleteThread();
            });
            
        }

        public void Init(string userid, string threadid)
        {
            ThreadId = threadid;
        }

        public async void DeleteThread()
        {
            var threads = await database.GetTable();
            foreach (var thread in threads)
            {
                if (thread.ThreadID == ThreadId)
                {
                    await database.DeleteTableRow(thread.Id);
                }
            }
        }

    }


}
