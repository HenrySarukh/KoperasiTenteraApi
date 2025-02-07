using KoperasiTenteraApi.Infrastructure.Persistance;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoperasiTenteraApi.Tests.Base
{
    // For integration tests
    public abstract class IntegrationBase : IDisposable
    {
        protected readonly KoperasiTenteraContext KoperasiTenteraContext;

        protected readonly IConfiguration Configuration;

        protected readonly SqliteConnection Connection;

        public IntegrationBase()
        {
            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            var contextOptions = new DbContextOptionsBuilder<KoperasiTenteraContext>()
                .UseSqlite(Connection)
                .EnableDetailedErrors()
                .Options;

            KoperasiTenteraContext = new KoperasiTenteraContext(contextOptions);

            KoperasiTenteraContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            CleanTables();

            Connection.Dispose();
            KoperasiTenteraContext.Dispose();
        }

        protected void CleanTables()
        {
            var dbSetProperties = KoperasiTenteraContext.GetType().GetProperties()
                .Where(p => p.PropertyType.IsGenericType &&
                            p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

            foreach (var dbSetProperty in dbSetProperties)
            {
                var dbSet = dbSetProperty.GetValue(KoperasiTenteraContext) as IQueryable;
                if (dbSet == null) continue;

                var entities = dbSet.Cast<object>().ToList();
                KoperasiTenteraContext.RemoveRange(entities);
            }

            KoperasiTenteraContext.SaveChanges();
        }
    }
}
