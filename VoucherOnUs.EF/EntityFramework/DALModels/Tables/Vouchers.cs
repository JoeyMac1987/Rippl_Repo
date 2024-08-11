using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoucherOnUs.EF.EntityFramework.DALModels
{
	public class Vouchers
	{
        [Key]
        public int VoucherID { get; set; }
        public string Name { get; set; }
        public int Value { get; set; }
        public int ProviderID { get; set; }
    }
}

