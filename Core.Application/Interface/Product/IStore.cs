using Core.Domain.BasicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Product
{
    public interface IStore
    {
        Task<bool> AddStore(Store store);
        Task<IEnumerable<Store>> GetStore();
        Task<bool> DeleteStore(int id);
        //Task<Store> GetStoreByCode(string code);
    }
}
