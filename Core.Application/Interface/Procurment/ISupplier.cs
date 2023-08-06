using Core.Domain.BasicInfo;
using Core.Domain.Procurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Procurment
{
    public interface ISupplier
    {
        Task<Supplier> AddSupplier(Supplier supplier);
        Task<IEnumerable<Supplier>> GeSupplier();
        Task<bool> DeleteSupplier(int id);
    }
}
