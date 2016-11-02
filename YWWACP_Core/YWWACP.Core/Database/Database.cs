using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MvvmCross.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.Database
{
    // ## Name: Andreas Norstein | ## Student number: 9805061


    /// <summary>
    /// Validation in all CheckIfExists must be fixed to check else than Pkeys
    /// ALL get-methodes returns a list with the the all myTable contents
    /// </summary>
    public class DatabaseTables : IDatabase
    {
        private SQLiteConnection database;
        
        public DatabaseTables()
        {
            var sqlite = Mvx.Resolve<ISqlite>();
            database = sqlite.GetConnection();
            database.CreateTable<MyTable>();
       
        }

        public async Task<IEnumerable<MyTable>> GetTable()
        {
            return database.Table<MyTable>().ToList();
        }

        public async Task<int> DeleteTableRow(object id)
        {
            return database.Delete<MyTable>(id);

        }

        public async Task<int> InsertTableRow(MyTable tablerow)
        {
            var num = database.Insert(tablerow);
            database.Commit();
            return num;
        }

        public async Task<bool> CheckIfExists(MyTable myTable)
        {
            var exists = database.Table<MyTable>()
                .Any(x => x.Id == myTable.Id);
            return exists;
        }
        
    }
}
