// <copyright file="IGenericRepository.cs" company="Star Wars Inc">
// Copyright (c) Star Wars Inc. All rights reserved.
// </copyright>

using System.Linq.Expressions;

namespace SW.DAL
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        public Task<IEnumerable<TEntity>> GetAsync(
            int pageNumber, int pageSize, Expression<Func<TEntity, bool>> filter = null);

        public Task<TEntity> GetByIdAsync(object id);

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null);

        public Task<TEntity> InsertAsync(TEntity entity);

        public Task<TEntity> DeleteAsync(object id);
    }
}
