using System;
using VouchersOnUs.BL.Interface;
using VouchersOnUs.BL.Models;
using VouchersOnUs.DAL.Interfaces;

namespace VouchersOnUs.BL
{
	public class Vouchers: IVouchers
	{
		
        private readonly IRepositoryBase<Voucher> repository;

        public Vouchers(IRepositoryBase<Voucher> repository)
        {
            this.repository = repository;
        }

        public void Create(Voucher Voucher)
        {
            repository.Create(Voucher);
        }

        public void Delete(int id)
        {
            Voucher? toDelete = Get(id) ?? throw new Exception("Voucher not found.");
            repository.Delete(toDelete);
        }

        public Voucher? Get(int id)
        {
            return repository.GetAll().SingleOrDefault(x => x.GUID == id);
        }

        public IEnumerable<Voucher> Get()
        {
            return repository.GetAll().ToList();
        }
    }
}

