using Core.Domain.BasicInfo;
using Core.Domain.Brand;
using Core.Domain.Procurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Procurment
{
    public interface IPurchaseOrder
    {
        Task<List<PurchaseOrder>> AddPurchaseOrder(List<PurchaseOrder> purchaseOrder);
        Task<IEnumerable<PurchaseOrder>> GetPurchaseOrder(string invoiceNo);
        Task<bool> DeletePurchaseOrder(int id);
        Task<Brand> GetBrandById(int id);
    }
}
