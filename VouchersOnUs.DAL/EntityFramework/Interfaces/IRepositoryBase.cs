using System;
namespace VouchersOnUs.DAL.Interfaces
{
    public interface IRepositoryBase<T> where T : class
    {
        IQueryable<T> GetAll();
        void Delete(T entity);
        void Create(T entity);
    }
}

