using Core.Domain.Authentication;
using Core.Domain.BasicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Product
{
    public interface IDashboard
    {
        Task<Dashboard> GetCompletePurchaseOrder();
        Task<Dashboard> GetPendingPurchaseOrder();
        Task<Registration> GetActiveUser();
        Task<Registration> GetInActiveUser();
    }
}
