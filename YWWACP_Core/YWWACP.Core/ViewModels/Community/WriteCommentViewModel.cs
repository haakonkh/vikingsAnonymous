using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.ViewModels.Community
{
    public class WriteCommentViewModel : MvxViewModel
    {
        private IDatabase database;
        public ICommand PostCommentCommand { get; set; }
        public ICommand BackCommand
        {
            get
            {
                return new MvxCommand(() => Close(this));
            }
        }

        private string tId;

        private string TId
        {
            get { return tId;}
            set
            {
                tId = value;
                RaisePropertyChanged(() => TId);
            }
        }

        private string commentContent;

        public string CommentContent
        {
            get { return commentContent; }
            set
            {
                if (value != null)
                {
                    SetProperty(ref commentContent, value);
                }
            }

        }

        public WriteCommentViewModel(IDatabase database)
        {
            this.database = database;

            PostCommentCommand = new MvxCommand(() =>
            {
             AddComment(new MyTable
             {
                 CommentContent = CommentContent,
                 CommentID = GetGeneratedCommentId(),
                 ThreadID = TId
             });
            });
        }

        public void Init(string tId)
        {
            TId = tId;
        }

        public async void AddComment(MyTable comment)
        {
            var x = await database.InsertTableRow(comment);
            Close(this);

        }

        public string GetGeneratedCommentId()
        {
            Guid g = Guid.NewGuid();
            string GuidString = Convert.ToBase64String(g.ToByteArray());
            GuidString = GuidString.Replace("=", "");
            GuidString = GuidString.Replace("+", "");

            string GS = Convert.ToBase64String(g.ToByteArray());
            GS = GuidString.Replace("=", "");
            GS = GuidString.Replace("+", "");
            return GuidString + GS;
        }

    }
}
