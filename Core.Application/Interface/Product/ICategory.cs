using Core.Domain.BasicInfo;
using Core.Domain.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Product
{
    public interface ICategory
    {
        Task<bool> AddCategory(Category model);
        Task<IEnumerable<Category>> GetCategory();
        Task<bool> DeleteCategory(int id);
    }
}
