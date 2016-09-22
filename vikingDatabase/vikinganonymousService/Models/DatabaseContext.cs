using Microsoft.Azure.Mobile.Server.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace vikinganonymousService.Models
{
    public class DatabaseContext : DbContext
    {
        private const string connectionStringName = "Name=MS_TableConnectionString";

        public DatabaseContext() : base(connectionStringName)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);modelBuilder.Conventions.Add(
                new AttributeToColumnAnnotationConvention<TableColumnAttribute, string>(
                    "ServiceTableColumn", (property, attributes) => attributes.Single().ColumnType.ToString()));
        }

        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.User> Users { get; set; }
        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.Threads> Threads { get; set; }
        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.Comments> Comments { get; set; }
        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.Comment> Comment { get; set; }
        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.Diary> Diarys { get; set; }
        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.Day> Days { get; set; }
        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.HealthPlan> HealthPlans { get; set; }
        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.Meal> Meals { get; set; }
        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.Exercise> Exercises { get; set; }

        public System.Data.Entity.DbSet<vikinganonymousService.DataObjects.Diary> Diaries { get; set; }
    }
}