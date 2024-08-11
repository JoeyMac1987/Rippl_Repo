using System;
using Microsoft.EntityFrameworkCore;
using VoucherOnUs.EF.EntityFramework.DALModels;

namespace VoucherOnUs.EF.EntityFramework.Interfaces
{
    public interface iVouchersOnUsDbContext
    {

        //Database Specific
        DbSet<Vouchers> Vouchers { get; set; }
        DbSet<Providers> Providers { get; set; }
        DbSet<Users> Users { get; set; }
        DbSet<Orders> Orders { get; set; }
    }
}
