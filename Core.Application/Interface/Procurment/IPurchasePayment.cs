
using Core.Domain.DBContext;
using Core.Domain.Procurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Core.Application.Interface.Procurment
{
    public interface IPurchasePayment
    {
        Task<List<GetUnPaidPO>> GetAll();
        Task<bool> UpdatePurchaseHeader(string invoiceNo);
    }
}
