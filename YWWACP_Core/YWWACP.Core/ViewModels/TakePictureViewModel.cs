using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Core.ViewModels;
using System.IO;
using System.Windows.Input;
using MvvmCross.Platform;
using MvvmCross.Plugins.PictureChooser;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.ViewModels
{
    public class TakePictureViewModel : MvxViewModel
    {
        private readonly IMvxPictureChooserTask _pictureChooserTask;
        public ICommand AddPictureCommand { get; set; }
        public TakePictureViewModel(IMvxPictureChooserTask pictureChooserTask)
        {
            _pictureChooserTask = pictureChooserTask;
            AddPictureCommand = new MvxCommand(()=>
            {
                AddPicture();
            });
        }

        private byte[] _pictureBytes;
        public byte[] PictureBytes
        {
            get { return _pictureBytes; }
            set { SetProperty(ref _pictureBytes, value); }
        }

        public IMvxCommand TakePictureCommand => new MvxCommand(TakePicture);

        private async void TakePicture()
        {
            var result = await _pictureChooserTask.TakePicture(1080, 100);
            var ms = new MemoryStream();
            await result.CopyToAsync(ms);
            PictureBytes = ms.ToArray();
        }

        public void AddPicture()
        {
            // Do something cool with the picture
            Mvx.Resolve<IToast>().Show("Picture not saved, it's just a beta");
            Close(this);
        }

    }
}
