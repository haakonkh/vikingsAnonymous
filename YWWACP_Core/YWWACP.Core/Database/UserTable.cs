using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YWWACP.Core.Interfaces;

namespace YWWACP.Core.Database
{
    public class DatabaseTables
    {
        private SQLiteConnection database;
        public DatabaseTables(ISqlite sqlite)
        {
            database = sqlite.GetConnection();
            database.CreateTable<User>().ToList();
        }
    }
}
