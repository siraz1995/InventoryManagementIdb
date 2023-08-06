using Core.Application.Interface.Product;
using Core.Domain.Authentication;
using Core.Domain.BasicInfo;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Product
{
    public class DashboardRepository : IDashboard
    {
        private readonly IDataAccess _db;
        public DashboardRepository(IDataAccess db)
        {
            _db = db;
        }
        public async Task<Dashboard> GetCompletePurchaseOrder()
        {
            string query = $@"Select Count(*)CompletePurchaseOrder from [Inventorymanagement].[dbo].[PurchaseHeader] where IsPaid=1";
            var result = await _db.Query<Dashboard, dynamic>(query, new { });
            return result.FirstOrDefault();
        }

        public async Task<Dashboard> GetPendingPurchaseOrder()
        {
            string query = $@"Select Count(*)PendingPurchaseOrder from [Inventorymanagement].[dbo].[PurchaseHeader] where IsPaid=0";
            var result = await _db.Query<Dashboard, dynamic>(query, new { });
            return result.FirstOrDefault();
        }
        public async Task<Registration> GetActiveUser()
        {
            string query = $@"Select Count(*)ActiveUser from [InventorymanagementSyatem].[dbo].[Registration] where IsActive=1";
            var result = await _db.Query<Registration, dynamic>(query, new { });
            return result.FirstOrDefault();
        }

        public async Task<Registration> GetInActiveUser()
        {
            string query = $@"Select Count(*)InActiveUser from [InventorymanagementSyatem].[dbo].[Registration] where IsActive=0";
            var result = await _db.Query<Registration, dynamic>(query, new { });
            return result.FirstOrDefault();
        }
    }
}
