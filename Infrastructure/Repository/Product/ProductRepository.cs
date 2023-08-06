using Core.Application.Interface.Product;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Product
{
    public class ProductRepository : IProductRepository
    {
        private readonly IDataAccess _db;
        public ProductRepository(IDataAccess db)
        {
            _db = db;
        }
        public async Task<bool> AddProduct(Core.Domain.BasicInfo.Product product)
        {
            if (product.Id == null || product.Id == 0)
            {
                try
                {
                    string query = "insert into Product(Name,Code,CategoryCode,BrandCode) values(@Name,@Code,@CategoryCode,@BrandCode)";
                    await _db.Command(query, new { Name = product.Name, Code = product.Code, CategoryCode = product.CategoryCode, BrandCode = product.BrandCode });
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
                    string query = "update Product set Name=@Name,Code=@Code,CategoryCode=@CategoryCode,BrandCode=@BrandCode where id=@Id";
                    await _db.Command(query, product);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }


        public async Task<List<Core.Domain.BasicInfo.Product>> GetProductList()
        {
            string query = $@"SELECT  
	                                P.Id,
	                                P.Name,
	                                P.Code,
	                                C.Name Category,P.CategoryCode,
	                                B.Name Brand,P.BrandCode
                                FROM Product P 
                                INNER JOIN Category C ON P.CategoryCode=C.Code
                                INNER JOIN Brand B ON P.BrandCode=B.Code
                                ORDER By P.Code Desc";
            var result = await _db.Query<Core.Domain.BasicInfo.Product, dynamic>(query, new { });
            return (List<Core.Domain.BasicInfo.Product>)result.ToList();
        }
        public async Task<bool> DeleteProductById(int id)
        {
            string query = $@"delete from Product where Id=@Id";
            await _db.Command(query, new { Id = id });
            return true;
        }
    }
}
