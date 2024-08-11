using System;
using VouchersOnUs.BL.Models;

namespace VouchersOnUs.BL.Interface
{
	public interface IVouchers
	{
        Voucher? Get(int id);
        IEnumerable<Voucher> Get();
        void Create(Voucher movie);
        void Delete(int id);
    }
}

