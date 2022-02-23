// <copyright file="IGenericRepository.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace SW.DAL
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

        public Task<TEntity> GetByIdAsync(object id);
        
        public Task<TEntity> InsertAsync(TEntity entity);

        public Task<TEntity> DeleteAsync(object id);
    }
}
