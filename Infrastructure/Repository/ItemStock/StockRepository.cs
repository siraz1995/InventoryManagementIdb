using Core.Application.Interface.Item_Stock;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.ItemStock
{
    public class StockRepository:IStockRepository
    {
        private readonly IDataAccess _db;
        public StockRepository(IDataAccess db)
        {
            _db = db;
        }

        public async Task<List<Core.Domain.Stock.ItemStock>> GetStockItem()
        {

            string query = $@"SELECT 
                                t1.Name, t1.ProductCode,
                                (((COALESCE(SUM(t1.qty),0)-COALESCE(SUM(t2.qty),0))-COALESCE(SUM(t3.Quantity),0))+COALESCE(SUM(t4.Quantity),0))Quantity from 
                                (SELECT 
                                    P.Name,PD.ProductCode,
                                    COALESCE(SUM(PD.Qty),0)qty
                                    FROM [Inventorymanagement].[dbo].PurchaseDetail PD
                                    LEFT JOIN [Inventorymanagement].[dbo].PurchaseHeader PH ON PD.InvoiceNo=PH.InvoiceNo
                                    INNER JOIN [InventorymanagementSyatem].[dbo].[Product] P ON PD.ProductCode=P.Code
                                    WHERE PH.IsPaid=1
                                    GROUP BY P.Name,PD.ProductCode) t1
                                Left Join 
                                (SELECT 
                                    P.Name, 
                                    COALESCE(SUM(PRI.qty),0)qty
                                    FROM [InventorymanagementSyatem].[dbo].[Product] P
                                    Inner Join [Inventorymanagement].[dbo].PurchaseOrederReturnInfo PRI on PRI.ProductCode = P.code
                                    group by P.Name) t2  
                                on t1.Name = t2.Name
                                LEFT JOIN
                                (Select 
                                     P.Name,
                                     COALESCE(SUM(SD.Quantity),0)Quantity
                                    FROM [InventorymanagementSyatem].[dbo].[Product] P
                                     INNER JOIN [Inventorymanagement].[dbo].[SalesDetail] SD on SD.ProductCode=p.Code
                                     Group by P.Name)t3
                                on t1.Name = t3.Name
                                LEFT JOIN
                                (Select
                                     P.Name,
                                     COALESCE(SUM(SRD.Quantity),0)Quantity
                                     from [Inventorymanagement].[dbo].SalesReturnDetail SRD
                                     INNER JOIN [InventorymanagementSyatem].[dbo].[Product] P on SRD.ProductCode=p.Code
                                     Group by P.Name)t4
                                on t1.Name=t4.Name
                                group by t1.Name,t1.ProductCode";
            var result = await _db.Query<Core.Domain.Stock.ItemStock, dynamic>(query, new { });
            return result.ToList();
        }
    }
}

//SELECT
//P.Name,
//COALESCE(SUM(PD.qty),0)qty
//FROM[InventorymanagementSyatem].[dbo].[Product] P
//Inner Join  [Inventorymanagement].[dbo].PurchaseDetail PD on P.code = PD.ProductCode
//group by P.Name