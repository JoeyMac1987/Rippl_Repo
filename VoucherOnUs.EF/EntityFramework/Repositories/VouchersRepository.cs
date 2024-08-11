using System;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.DALModels;
using VoucherOnUs.EF.EntityFramework.Interfaces;

namespace VoucherOnUs.EF.EntityFramework.Repositories
{
	public class VouchersRepository : RepositoryBase<Vouchers> , IVouchersRepository
	{
		public VouchersRepository( VouchersOnUsDBContext context ): base(context)
		{
			this.dbSet = context.Set<Vouchers>();
		}
	}
}

