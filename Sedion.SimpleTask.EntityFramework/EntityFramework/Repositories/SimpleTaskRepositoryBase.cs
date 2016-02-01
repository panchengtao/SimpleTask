using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace Sedion.SimpleTask.EntityFramework.Repositories
{
    public abstract class SimpleTaskRepositoryBase<TEntity, TPrimaryKey> : EfRepositoryBase<SimpleTaskDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected SimpleTaskRepositoryBase(IDbContextProvider<SimpleTaskDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class SimpleTaskRepositoryBase<TEntity> : SimpleTaskRepositoryBase<TEntity, int>
        where TEntity : class, IEntity<int>
    {
        protected SimpleTaskRepositoryBase(IDbContextProvider<SimpleTaskDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //do not add any method here, add to the class above (since this inherits it)
    }
}
