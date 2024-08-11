using System;
using VouchersOnUs.DAL.Interfaces;

namespace VouchersOnUs.DAL.EntityFramework.Repositories
{
	public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DataContext context;

        public RepositoryBase(DataContext context)
        {
            this.context = context;
        }

        public void Create(T entity)
        {
            context.Set<T>().Add(entity);
            context.SaveChanges();
        }

        public void Delete(T entity)
        {
            context.Remove(entity);
            context.SaveChanges();
        }

        public IQueryable<T> GetAll()
        {
            return context.Set<T>();
        }
    }
}

