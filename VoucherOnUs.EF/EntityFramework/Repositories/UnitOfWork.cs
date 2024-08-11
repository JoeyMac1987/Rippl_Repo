using System;
using VoucherOnUs.EF.EntityFramework.Interfaces;

namespace VoucherOnUs.EF.EntityFramework.Repositories
{
	public class UnitOfWork : IUnitOfWork
	{
        //Databases
        private readonly iVouchersOnUsDbContext _context;

        //Table Interfaces
        private readonly IVouchersRepository _vouchersRepository;
        private readonly IProvidersRepository _providersRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IOrdersRepository _ordersRepository;


        public UnitOfWork(iVouchersOnUsDbContext context,
                            IVouchersRepository vouchersRepository,
                            IProvidersRepository providersRepository,
                            IUsersRepository usersRepository,
                            IOrdersRepository ordersRepository
                            )
		{
            //Databases
            _context = context;

            //Table interfaces
            _vouchersRepository = vouchersRepository;
            _providersRepository = providersRepository;
            _usersRepository = usersRepository;
            _ordersRepository = ordersRepository;
        }

        public iVouchersOnUsDbContext VouchersOnUsDbContext
        {
            get { return _context; }
        }


        #region InterfaceAccess
        public IVouchersRepository VouchersRepository
        {
            get { return _vouchersRepository; }
        }
        public IProvidersRepository ProvidersRepository
        {
            get { return _providersRepository; }
        }
        public IUsersRepository UsersRepository
        {
            get { return _usersRepository; }
        }
        public IOrdersRepository OrdersRepository
        {
            get { return _ordersRepository;  }
        }


        #endregion
    }
}

