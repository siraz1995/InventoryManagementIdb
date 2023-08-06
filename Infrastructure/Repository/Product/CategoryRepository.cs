using Core.Application.Interface.Product;
using Core.Domain.BasicInfo;
using Core.Domain.Brand;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Product
{
    public class CategoryRepository : ICategory
    {
        private readonly IDataAccess _db;
        public CategoryRepository(IDataAccess db)
        {
            _db = db;
        }
        public async Task<bool> AddCategory(Category category)
        {
            if (category.Id == null ||category.Id==0)
            {
                try
                {
                    string query = "insert into Category(name,code) values(@Name,@Code)";
                    await _db.Command(query, new { Name = category.Name, Code = category.Code });
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            else
            {
                try
                {
                    string query = "update Category set name=@Name,code=@Code where id=@Id";
                    await _db.Command(query, category);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<IEnumerable<Category>> GetCategory()
        {
            string query = "select * from Category order by Code desc";
            var result = await _db.Query<Category, dynamic>(query, new { });
            return result;
        }
        public async Task<bool> DeleteCategory(int id)
        {
            try
            {
                string query = "delete from Category where id = @Id";
                await _db.Command(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}
