using Core.Application.Interface.Procurment;
using Core.Domain.DBContext;
using Core.Domain.Procurement;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Procurment
{
    public class PurchasePaymentRepository : IPurchasePayment
    {
        private readonly IDataAccess _db;
        public PurchasePaymentRepository(IDataAccess db)
        {
            _db = db;
        }
        public async Task<List<GetUnPaidPO>> GetAll()
        {
            string query = $@"Select
                                PH.InvoiceNo,
                                PH.InvoiceDate,
                                V.[Name] VendorName,
                                S.[Name] ShopName,
                                PH.NetTotal,
                                PH.IsPaid
                                From [Inventorymanagement].[dbo].[PurchaseHeader] PH
                                INNER JOIN [InventorymanagementSyatem].[dbo].[Supplier] V ON PH.VendorCode=V.Code
                                INNER JOIN [InventorymanagementSyatem].[dbo].[Store] S ON PH.ShopCode=S.Code
                                Order By PH.IsPaid asc";
            var result = await _db.Query<GetUnPaidPO,dynamic>(query, new { });
            return result.ToList();
        }

        public async Task<bool> UpdatePurchaseHeader(string invoiceNo)
        {
            if (invoiceNo == null)
            {
                return false;
            }
            else
            {
            string query = $@"Update [Inventorymanagement].[dbo].[PurchaseHeader] set IsPaid=1 where invoiceNo=@InvoiceNo";
            //await _db.Command(query, new { InvoiceNo = invoiceNo });
            await _db.CommandAsync(query, new { InvoiceNo = invoiceNo });
            return true;
            }
        }
    }
}
