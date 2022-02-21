using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SW.DAL
{
    public interface IGenericRepository<TEntity> where TEntity: class
    {
        public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter);

        public Task<TEntity> GetByIdAsync(object id);
        
        public Task<TEntity> InsertAsync(TEntity entity);

        public Task<TEntity> DeleteAsync(object id);
    }
}
