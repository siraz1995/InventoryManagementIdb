using Core.Domain.BasicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Product
{
    public interface IProductRepository
    {
        Task<bool> AddProduct(Core.Domain.BasicInfo.Product product);
        Task<List<Core.Domain.BasicInfo.Product>>GetProductList();
        Task<bool> DeleteProductById(int id);
    }
}
