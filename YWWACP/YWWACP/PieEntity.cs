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

namespace YWWACP
{
 public class PieEntity
    {

        public string EntityType{ get; set; }
        public string EntityNymber { get; set; }

       
        public PieEntity() { }
        public PieEntity(string entityType, string entityNumber)
        {
          EntityType = entityType;
            EntityNymber = entityNumber;
            
        }

    }
}