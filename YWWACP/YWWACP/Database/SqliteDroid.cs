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
using SQLite.Net;
using System.IO;
using YWWACP.Core.Interfaces;

namespace YWWACP
{
    public class SQLiteDroid : ISqlite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFilename = "LocationSQLite.db3";
            string documentsPath = System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal);

            var path = Path.Combine(documentsPath, sqliteFilename);
            // Create the connection

            var conn = new SQLiteConnection(new
                SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid(), path);
            // Return the database connection
            return conn;
        }
    }
}