using System;
using Microsoft.AspNetCore.Mvc;

namespace VouchersOnUs.API.DTO
{
    //[BindProperties]
	public class OrdersDTO
	{
        public Guid GUID { get; set; }
        public int OrderId { get; set; }
        public int UserID { get; set; }
        public int ProviderID { get; set; }
        public int VoucherID { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

