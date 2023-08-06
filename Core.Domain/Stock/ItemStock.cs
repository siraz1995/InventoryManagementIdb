using Core.Domain.BasicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Stock
{
    public class ItemStock
    {
        //public int Id { get; set; }
        //public string Store { get; set; }
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public decimal Quantity { get; set; }
    }
}
