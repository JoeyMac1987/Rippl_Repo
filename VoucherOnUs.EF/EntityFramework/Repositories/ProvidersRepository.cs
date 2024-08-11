using System;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.DALModels;
using VoucherOnUs.EF.EntityFramework.Interfaces;

namespace VoucherOnUs.EF.EntityFramework.Repositories
{
	public class ProvidersRepository : RepositoryBase<Providers> , IProvidersRepository 
	{
		public ProvidersRepository(VouchersOnUsDBContext context) : base(context)
    {
        this.dbSet = context.Set<Providers>();
    }
}
}

