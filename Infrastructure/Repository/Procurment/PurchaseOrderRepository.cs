using Core.Application.Interface.Procurment;
using Core.Domain.Brand;
using Core.Domain.Procurement;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Procurment
{
    public class PurchaseOrderRepository : IPurchaseOrder
    {
        private readonly IDataAccess _db;
        public PurchaseOrderRepository(IDataAccess db)
        {
            _db = db;
        }
        public async Task<List<PurchaseOrder>> AddPurchaseOrder(List<PurchaseOrder> purchaseOrder)
        {

            foreach (var item in purchaseOrder)
            {
                if (item.Id == null || item.Id == 0)
                {
                    try
                    {
                        string query = "insert into PurchaseOrder(InvoiceNo,SupplierCode,StoreCode,PurchaseOrderDate,ItemName,BrandCode,CategoryCode,Quantity,PurchasePrice,TaxAmount,TotalAmount,UnitTypeCode,IsExpirable,Status)values(@InvoiceNo,@SupplierCode,@StoreCode,@PurchaseOrderDate,@ItemName,@BrandCode,@CategoryCode,@Quantity,@PurchasePrice,@TaxAmount,@TotalAmount,@UnitTypeCode,@IsExpirable,@Status)";
                        await _db.Command(query, new
                        {
                            InvoiceNo = item.InvoiceNo,
                            SupplierCode = item.SupplierCode,
                            StoreCode = item.StoreCode,
                            PurchaseOrderDate = item.PurchaseOrderDate,
                            ItemName = item.ItemName,
                            BrandCode = item.BrandCode,
                            CategoryCode = item.CategoryCode,
                            Quantity = item.Quantity,
                            PurchasePrice = item.PurchasePrice,
                            TaxAmount = item.TaxAmount,
                            TotalAmount = item.TotalAmount,
                            UnitTypeCode = item.UnitTypeCode,
                            IsExpirable = item.IsExpirable,
                            Status = item.Status
                        });
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error Occur");
                    }
                }
                else
                {
                    try
                    {
                        string query = "update PurchaseOrder set InvoiceNo=@InvoiceNo,SupplierCode=@SupplierCode,StoreCode=@StoreCode,PurchaseOrderDate=@PurchaseOrderDate,ItemName=@ItemName,BrandCode=@BrandCode,CategoryCode=@CategoryCode,Quantity=@Quantity,PurchasePrice=@PurchasePrice,TotalAmount=@TotalAmount,UnitTypeCode=@UnitTypeCode,IsExpirable=@IsExpirable,Status=@Status where id=@Id";
                        await _db.Command(query, purchaseOrder);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Error Occur");
                    }
                }
            }
            return purchaseOrder;

        }
        public async Task<Brand> GetBrandById(int id)
        {
            string query = "select * from Brand where id=@Id";
            IEnumerable<Brand> brand = await _db.Query<Brand, dynamic>(query, new { Id = id });
            return brand.FirstOrDefault();
        }

        public async Task<bool> DeletePurchaseOrder(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PurchaseOrder>> GetPurchaseOrder(string invoiceNo)
        {
            string query = "select * from PurchaseOrder where invoiceNo=@InvoiceNo";
            IEnumerable<PurchaseOrder> purchaseOrder = await _db.Query<PurchaseOrder, dynamic>(query, new { InvoiceNo = invoiceNo });
            return purchaseOrder.ToList();
        }
    }
}
