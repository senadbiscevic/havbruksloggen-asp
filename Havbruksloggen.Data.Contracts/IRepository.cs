﻿using System.Threading.Tasks;

namespace Havbruksloggen.Data.Contracts
{
    public interface IRepository
    {
        void Add<TEntity>(TEntity entity) where TEntity : class;

        void Update<TEntity>(TEntity entity) where TEntity : class;

        void Remove<TEntity>(TEntity entity) where TEntity : class;

        int CommitChanges();

        Task<int> CommitChangesAsync();
    }
}
