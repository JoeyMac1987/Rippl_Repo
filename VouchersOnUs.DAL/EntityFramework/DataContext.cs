using System;
using Microsoft.EntityFrameworkCore;
using VouchersOnUs.DAL.Entities;

namespace VouchersOnUs.DAL
{
	public class DataContext : DbContext
	{
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Voucher> Vouchers { get; set; }
        
    }
}

