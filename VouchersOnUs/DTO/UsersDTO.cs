using System;
namespace VouchersOnUs.API.DTO
{
	public class UsersDTO
	{
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserAddress { get; set; }
        public string UserEmail { get; set; }
        public bool Active { get; set; }
    }
}

