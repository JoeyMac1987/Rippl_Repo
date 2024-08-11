using System;
namespace VouchersOnUs.API.DTO
{
    public class VouchersDTO
    {
        public int VoucherID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int ProviderID { get; set; }

        public string? VoucherDescription {get;set;}
    }
}

