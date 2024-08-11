using System;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.DALModels;
using VoucherOnUs.EF.EntityFramework.Interfaces;
using VouchersOnUs.API.Controllers;

namespace VouchersOnUs.API.Repositories
{
	public class UsersRepository
	{
        private VouchersOnUsDBContext _repository;
        private IUnitOfWork _unitofWork;
        private IConfiguration _config;

        //Method of tracking issues
        private readonly ILogger<VouchersOnUsController> _logger;

        public UsersRepository(VouchersOnUsDBContext repository, IUnitOfWork unitofWork, IConfiguration config, ILogger<VouchersOnUsController> logger)
        {
            _repository = repository;
            _config = config;
            _unitofWork = unitofWork;

            _logger = logger;
        }


        public Users GetUser (int UserID)
        {
            var user = _unitofWork.UsersRepository.FindAll().Where(x => x.UserId == UserID).FirstOrDefault();

            return user;

        }
    }
}

