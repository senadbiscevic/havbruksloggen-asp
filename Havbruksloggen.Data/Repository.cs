using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Havbruksloggen.Data
{
    public abstract class Repository
    {
        protected HavbruksloggenContext DbContext;

        public Repository(HavbruksloggenContext dbContext)
        {
            DbContext = dbContext;
        }

        public virtual void Add<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Add(entity);
        }

        public virtual void Update<TEntity>(TEntity entity) where TEntity : class
        {
            DbContext.Set<TEntity>().Update(entity);
        }

        public virtual void Remove<TEntity>(TEntity entity) where TEntity : class
            => DbContext.Set<TEntity>().Remove(entity);

        public int CommitChanges()
        {
            return DbContext.SaveChanges();
        }

        public Task<int> CommitChangesAsync()
        {
            return DbContext.SaveChangesAsync();
        }
    }
}
