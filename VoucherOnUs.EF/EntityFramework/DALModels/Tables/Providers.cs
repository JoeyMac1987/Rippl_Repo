using System;
using System.ComponentModel.DataAnnotations;

namespace VoucherOnUs.EF.EntityFramework.DALModels
{
	public class Providers
	{
        [Key]
        public int ProviderID { get; set; }
        public string ProviderName { get; set; }
        public string ProviderAPIURL { get; set; }
    }
}

