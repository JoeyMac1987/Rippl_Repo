using System;
using System.Linq.Expressions;

namespace VoucherOnUs.EF.EntityFramework.Interfaces
{
	public interface IRepositoryBase<TEntity> where TEntity : class
    {
        IQueryable<TEntity> FindAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);

        TEntity FindById(object id);

        TEntity FindById(object id, params Expression<Func<TEntity, object>>[] includes);

        IQueryable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
           params Expression<Func<TEntity, object>>[] includes);
    }
}

