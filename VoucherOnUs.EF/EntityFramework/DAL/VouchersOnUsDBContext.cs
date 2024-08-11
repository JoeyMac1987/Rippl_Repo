using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using VoucherOnUs.EF.EntityFramework.DALModels;
using VoucherOnUs.EF.EntityFramework.Interfaces;

namespace VoucherOnUs.EF.EntityFramework.DAL
{
	public class VouchersOnUsDBContext : DbContext, iVouchersOnUsDbContext
	{

        protected readonly IConfiguration Configuration;

        public VouchersOnUsDBContext(IConfiguration configuration, DbContextOptions<VouchersOnUsDBContext> options) : base(options)

        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration["VouchersOnUs:Database"]);
        }

        #region DatabaseTables
        public DbSet<Vouchers> Vouchers { get; set; }
        public DbSet<Providers> Providers { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Orders> Orders { get; set; }
        #endregion

    }


}