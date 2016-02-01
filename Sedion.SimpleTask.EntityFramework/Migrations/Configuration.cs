using System.Data.Entity.Migrations;
using Sedion.SimpleTask.Migrations.SeedData;

namespace Sedion.SimpleTask.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<SimpleTask.EntityFramework.SimpleTaskDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SimpleTask";
        }

        protected override void Seed(SimpleTask.EntityFramework.SimpleTaskDbContext context)
        {
            new InitialDataBuilder(context).Build();
        }
    }
}
