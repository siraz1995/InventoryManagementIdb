using Core.Domain.Brand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Core.Applicatio
{
    public interface IBrand
    {
        Task<bool> AddBrand(Brand brand);
        //Task<bool> UpdateBrand(Brand brand);
        Task<Brand> GetBrandById(int id);
        Task<bool> DeleteBrand(int id);
        Task<IEnumerable<Brand>> GetBrand();
    }
}

