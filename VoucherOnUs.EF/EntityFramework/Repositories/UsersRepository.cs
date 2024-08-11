using System;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.DALModels;
using VoucherOnUs.EF.EntityFramework.Interfaces;

namespace VoucherOnUs.EF.EntityFramework.Repositories
{
	public class UsersRepository : RepositoryBase<Users> , IUsersRepository 
	{
		public UsersRepository(VouchersOnUsDBContext context) : base(context)
		{
			this.dbSet = context.Set<Users>();
		}
	}
}


