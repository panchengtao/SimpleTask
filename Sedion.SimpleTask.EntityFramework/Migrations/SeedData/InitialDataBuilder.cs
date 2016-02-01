using Sedion.SimpleTask.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Sedion.SimpleTask.Migrations.SeedData
{
    public class InitialDataBuilder
    {
        private readonly SimpleTaskDbContext _context;

        public InitialDataBuilder(SimpleTaskDbContext context)
        {
            _context = context;
        }

        public void Build()
        {
            _context.DisableAllFilters();

            new DefaultEditionsBuilder(_context).Build();
            new DefaultTenantRoleAndUserBuilder(_context).Build();
            new DefaultLanguagesBuilder(_context).Build();
        }
    }
}
