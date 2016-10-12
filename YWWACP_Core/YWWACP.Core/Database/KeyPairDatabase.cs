using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using SQLite.Net;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.Database
{
    public class KeyPairDatabase
    {
        private SQLiteConnection database;

        public KeyPairDatabase()
        {
            database = Mvx.Resolve<ISqlite>().GetConnection();
            database.CreateTable<KeyPair>();
        }

        public KeyPair GetValue(string key)
        {
            return database.Table<KeyPair>().FirstOrDefault(x => x.Key == key);
        }

        public int InsertOrUpdateValue(KeyPair keyPair)
        {
            var num = database.InsertOrReplace(keyPair);
            database.Commit();
            return num;

        }
    }
}
