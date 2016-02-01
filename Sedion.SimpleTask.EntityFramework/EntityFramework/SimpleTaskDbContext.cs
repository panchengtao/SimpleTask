using System.Data.Common;
using Abp.Zero.EntityFramework;
using Sedion.SimpleTask.Authorization.Roles;
using Sedion.SimpleTask.MultiTenancy;
using Sedion.SimpleTask.Users;

namespace Sedion.SimpleTask.EntityFramework
{
    public class SimpleTaskDbContext : AbpZeroDbContext<Tenant, Role, User>
    {
        //TODO: Define an IDbSet for your Entities...

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public SimpleTaskDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in SimpleTaskDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of SimpleTaskDbContext since ABP automatically handles it.
         */
        public SimpleTaskDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public SimpleTaskDbContext(DbConnection connection)
            : base(connection, true)
        {

        }
    }
}
