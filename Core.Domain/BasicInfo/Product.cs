using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Core.Domain.BasicInfo
{
    public class Product
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public string Category { get; set; }
        public string CategoryCode { get; set; }
        public string Brand { get; set; }
        public string BrandCode { get; set; }
    }
}
