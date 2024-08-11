using System;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.DALModels;
using VoucherOnUs.EF.EntityFramework.Interfaces;


namespace VoucherOnUs.EF.EntityFramework.Repositories
{
	public class OrdersRepository : RepositoryBase<Orders>, IOrdersRepository
	{

        public OrdersRepository(VouchersOnUsDBContext context) : base(context)
        {
            this.dbSet = context.Set<Orders>();
        }


    }
}

