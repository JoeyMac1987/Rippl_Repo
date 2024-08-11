using System;

namespace VoucherOnUs.EF.EntityFramework.Interfaces
{
	public interface IUnitOfWork
	{
		iVouchersOnUsDbContext VouchersOnUsDbContext { get;  }

		IVouchersRepository VouchersRepository { get;  }

        IProvidersRepository ProvidersRepository { get; }

		IUsersRepository UsersRepository { get; }

		IOrdersRepository OrdersRepository { get; }

    }
}

