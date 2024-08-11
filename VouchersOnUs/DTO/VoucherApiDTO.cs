using System;
namespace VouchersOnUs.API.DTO
{
	public class VoucherApiDTO
	{
		public List<VouchersDTO> VouchersList { get; set; }
		public List<OrdersDTO> OrdersList { get; set; }
		public List<UsersDTO> UsersList { get; set; }
		public int Amount { get; set; }
	}
}

