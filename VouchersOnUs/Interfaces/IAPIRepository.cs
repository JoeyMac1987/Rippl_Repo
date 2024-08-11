using System;
using System.Linq.Expressions;

namespace VouchersOnUs.API.Interfaces
{
	    //Test Generic Interface
        public interface IAPIRepository<T> where T : Type
        {
            //public IEnumerable<T> GetAll();
            public T Get(string value);
            //public T Post(T entity);
            //public T Put(T entity);
            //public void Delete(string id);
        }

}

