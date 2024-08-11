using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.Interfaces;


namespace VoucherOnUs.EF.EntityFramework.Repositories
{


    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        internal iVouchersOnUsDbContext _context;
        internal DbSet<TEntity> dbSet;
        public iVouchersOnUsDbContext Context { get; set; }

        protected VouchersOnUsDBContext VouchersOnUsDbContext { get; set; }

        public RepositoryBase( VouchersOnUsDBContext context)
        {
            _context = context;
            this.VouchersOnUsDbContext = context;
            this.dbSet = context.Set<TEntity>();
            Context = _context;
        }


        public IQueryable<TEntity> FindAll()
        {
            return this.VouchersOnUsDbContext.Set<TEntity>().AsNoTracking();
        }

        public void Create(TEntity entity)
        {
            this.VouchersOnUsDbContext.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            this.VouchersOnUsDbContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            this.VouchersOnUsDbContext.Set<TEntity>().Remove(entity);
        }

        public TEntity FindById(object id)
        {
            return dbSet.Find(id);
        }

        public TEntity FindById(object id, params Expression<Func<TEntity, object>>[] includes)
        {
            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    dbSet.Include(include);
                }
            }

            return dbSet.Find(id);

        }


        public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includes)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includes.Any())
            {
                foreach (var include in includes)
                {
                    query = query.Include(include);
                }
            }

            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }



    }
    
}

