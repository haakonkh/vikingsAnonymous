using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Microsoft.WindowsAzure.MobileServices;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Database
{
    public class AzureDatabase : IAzureDatabase
    {
        MobileServiceClient azureDatabase;

        public MobileServiceClient GetMobileServiceClient()
        {
            CurrentPlatform.Init();
            azureDatabase = new MobileServiceClient("https://vikinganonymous.azurewebsites.net");
            InitializeLocal();
            return azureDatabase;
        }

        private void InitializeLocal()
        {
            var sqliteFilename = "LocationSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);
            if (!File.Exists(path))
            {
                File.Create(path).Dispose();
            }
            var store = new MobileServiceSQLiteStore(path);
            store.DefineTable<MyTable>();
            azureDatabase.SyncContext.InitializeAsync(store);
        }


    }
}