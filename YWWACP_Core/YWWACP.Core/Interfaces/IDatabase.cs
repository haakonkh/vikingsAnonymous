﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YWWACP.Core.Models;

namespace YWWACP.Core.Interfaces
{
   public interface IDatabase
    {

        Task<IEnumerable<MyTable>> GetTable();
        Task<int> DeleteTableRow(object id);
        Task<int> InsertTableRow(MyTable tablerow);
        Task<bool> CheckIfExists(MyTable tablerow);

    }
}
