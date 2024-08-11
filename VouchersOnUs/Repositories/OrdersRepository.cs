using System;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using VoucherOnUs.EF.EntityFramework.DAL;
using VoucherOnUs.EF.EntityFramework.DALModels;
using VoucherOnUs.EF.EntityFramework.Interfaces;
using VouchersOnUs.API.Controllers;
using VouchersOnUs.API.DTO;

namespace VouchersOnUs.API.Repositories
{
	public class OrdersRepository
	{
        private VouchersOnUsDBContext _repository;
        private IUnitOfWork _unitofWork;
        private IConfiguration _config;

        //Method of tracking issues
        private readonly ILogger<VouchersOnUsController> _logger;

        public OrdersRepository(VouchersOnUsDBContext repository, IUnitOfWork unitofWork, IConfiguration config, ILogger<VouchersOnUsController> logger)
        {
            _repository = repository;
            _config = config;
            _unitofWork = unitofWork;

            _logger = logger;
        }


        public List<Orders> GetUserOrder(int UserID)
        {
            var userOrder = _unitofWork.OrdersRepository.FindAll().Where(x => x.UserID == UserID).ToList();

            return userOrder;

        }

        public bool AddOrder(OrdersDTO order)
        {

            bool outcome = false;

            Orders dbTableRecord = new Orders();

            dbTableRecord.OrderID = order.OrderId;
            dbTableRecord.ProviderID = order.ProviderID;
            dbTableRecord.Quantity = order.Quantity;
            dbTableRecord.TimeStamp = DateTime.Now;
            dbTableRecord.Total = order.Total;
            dbTableRecord.UserID = order.UserID;
            dbTableRecord.VoucherID = order.VoucherID;

            try
            {
                _repository.Orders.Add(dbTableRecord);
                //save everything via EFcore
                _repository.SaveChanges();
                outcome = true;
                return outcome;
            }
            catch (Exception ex)
            {
                var placeholder = ex.Message;
                return outcome;
            }

        }
    }
}

