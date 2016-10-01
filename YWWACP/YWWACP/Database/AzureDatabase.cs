using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;

namespace YWWACP.Database
{
    class AzureDatabase
    {
        public MobileServiceClient GetMobileServiceClient()
        {
            CurrentPlatform.Init();
            var client = new MobileServiceClient("https://vikinganonymous.azurewebsites.net");
            return client;
        }

  
    }
}