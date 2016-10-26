using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using MvvmCross.Platform;
using YWWACP.Core.Interfaces;
using YWWACP.Core.Models;

namespace YWWACP.Core.Database
{
    public class DatabaseAzure : IDatabase
    {
        private MobileServiceClient azureDatabase;
        private IMobileServiceSyncTable<MyTable> azureSyncTable;

        public  DatabaseAzure()
        {
            azureDatabase = Mvx.Resolve<IAzureDatabase>().GetMobileServiceClient();
            azureSyncTable = azureDatabase.GetSyncTable<MyTable>();
        }

        public async Task<bool> CheckIfExists(MyTable tablerow)
        {
            await SyncAsync(true);
            var mytablerow = await azureSyncTable.Where(x => x.UserId == tablerow.UserId || x.Id == tablerow.Id).ToListAsync();
            azureDatabase.Dispose();
            return mytablerow.Any();
        }

        public async Task<int> DeleteTableRow(object id)
        {
            await SyncAsync(true);
            var mytablerow = await azureSyncTable.Where(x => x.Id == (int)id).ToListAsync();
            if (mytablerow.Any())
            {
                await azureSyncTable.DeleteAsync(mytablerow.FirstOrDefault());
                await SyncAsync();
                azureDatabase.Dispose();

                return 1;
            }
            else
            {
                azureDatabase.Dispose();

                return 0;

            }
        }

        public async Task<IEnumerable<MyTable>> GetTable()
        {
            await SyncAsync(true);
            var mytable = await azureSyncTable.ToListAsync();
            azureDatabase.Dispose();

            return mytable;
        }

        public async Task<int> InsertTableRow(MyTable tablerow)
        {
            await SyncAsync(true);
            await azureSyncTable.InsertAsync(tablerow);
            await SyncAsync();
            azureDatabase.Dispose();

            return 1;
        }


        private async Task SyncAsync(bool pullData = false)
        {
            try
            {
                await azureDatabase.SyncContext.PushAsync();

                if (pullData)
                {
                    await azureSyncTable.PullAsync("MyTable", azureSyncTable.CreateQuery()); // query ID is used for incremental sync
                }
            }

            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }


    }
}
