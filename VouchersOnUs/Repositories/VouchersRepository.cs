using System;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.Interfaces;
using VouchersOnUs.API.Controllers;
using VouchersOnUs.API.DTO;

namespace VouchersOnUs.API.Repositories
{
	public class VouchersRepository
	{
        private VouchersOnUsDBContext _repository;
        private IUnitOfWork _unitofWork;
        private IConfiguration _config;

        //Method of tracking issues
        private readonly ILogger<VouchersOnUsController> _logger;

        public VouchersRepository(VouchersOnUsDBContext repository, IUnitOfWork unitofWork, IConfiguration config, ILogger<VouchersOnUsController> logger)
        {
            _repository = repository;
            _config = config;
            _unitofWork = unitofWork;

            _logger = logger;
        }

        public List<VouchersDTO> GetAllVouchers()
        {

            List<VouchersDTO> returnValues = new List<VouchersDTO>();

            var dbValues = _unitofWork.VouchersRepository.FindAll().ToList(); ;

            returnValues = (from a in _repository.Vouchers
                        select new VouchersDTO
                        {
                            VoucherID = a.VoucherID,
                            Name = a.Name,
                            Value = a.Value,
                            ProviderID = a.ProviderID
                        }
                        ).ToList();

            return returnValues;
        }
    }
}

