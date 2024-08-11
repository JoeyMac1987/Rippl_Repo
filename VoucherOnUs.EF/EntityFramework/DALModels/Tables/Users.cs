using System;
using System.ComponentModel.DataAnnotations;

namespace VoucherOnUs.EF.EntityFramework.DALModels
{
	public class Users
	{
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail{ get; set; }
        public bool Active { get; set; }
    }
}

