using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Supermarket.Shared.Models
{
    public class ItemDetails
    {
        [Key]
        public int ItemCode { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string ItemName { get; set; }
        public double UnitPrice { get; set; }
        public double Stock { get; set; }
    }
}
