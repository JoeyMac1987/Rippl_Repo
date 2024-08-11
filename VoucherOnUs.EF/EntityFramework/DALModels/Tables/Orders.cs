using System;
using System.ComponentModel.DataAnnotations;

namespace VoucherOnUs.EF.EntityFramework.DALModels
{
    public class Orders
    {
        [Key]
        public Guid GUID { get; set; }
        public int OrderID { get; set; }
        public int UserID { get; set; }
        public int ProviderID { get; set; }
        public int VoucherID { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}

