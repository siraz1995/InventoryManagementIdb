using Core.Applicatio;
using Core.Domain.Brand;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class BrandRepository : IBrand
    {
        private readonly IDataAccess _db;
        public BrandRepository(IDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddBrand(Brand brand)
        {
            if (brand.Id == null || brand.Id == 0)
            {
                try
                {
                    string query = "insert into Brand(name,code) values(@Name,@Code)";
                    await _db.Command(query, new { Name = brand.Name, Code = brand.Code });
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    string query = "update Brand set name=@Name,code=@Code where id=@Id";
                    await _db.Command(query, brand);
                }
                catch(Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        //public async Task<bool> UpdateBrand(Brand brand)
        //{
        //    try
        //    {
        //        string query = "update Brand set name=@Name,code=@Code where id=@Id";
        //        await _db.SaveData(query, brand);
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        public async Task<bool> DeleteBrand(int id)
        {
            try
            {
                string query = "delete from Brand where id = @Id";
                await _db.Command(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Brand>> GetBrand()
        {
            string query = "select * from Brand order by Code desc";
            var brand = await _db.Query<Brand, dynamic>(query, new { });
            return brand;
        }

        public async Task<Brand> GetBrandById(int id)
        {
            string query = "select * from Brand where id=@Id";
            IEnumerable<Brand> brand = await _db.Query<Brand, dynamic>(query, new { Id = id });
            return brand.FirstOrDefault();
        }

    }
}
