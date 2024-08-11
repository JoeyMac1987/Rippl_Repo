using System;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.Interfaces;
using VouchersOnUs.API.Controllers;

namespace VouchersOnUs.API.Repositories
{
	public class ProvidersRepository
	{
		private VouchersOnUsDBContext _repository;
        private IUnitOfWork _unitofWork;
        private IConfiguration _config;

        //Method of tracking issues
        private readonly ILogger<VouchersOnUsController> _logger;

        public ProvidersRepository(VouchersOnUsDBContext repository, IUnitOfWork unitofWork, IConfiguration config, ILogger<VouchersOnUsController> logger)
        {
            _repository = repository;
            _config = config;
            _unitofWork = unitofWork;

            _logger = logger;
        }


        public string GetProviderApiUrl( string providersName)
        {

            string returnURL = "";

            var providerRecord = _unitofWork.ProvidersRepository.FindAll().Where(x=> x.ProviderName == providersName).FirstOrDefault();

            //add logic to handle unfound
            returnURL = (providerRecord.ProviderAPIURL.Length >0) ? providerRecord.ProviderAPIURL : "error" ;




            //

            return returnURL;

        }
    
	}
}

