using Core.Application.Interface.Product;
using Core.Domain.BasicInfo;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Product
{
    public class StoreRepository : IStore
    {

        private readonly IDataAccess _db;
        public StoreRepository(IDataAccess db)
        {
            _db = db;
        }

        public async Task<bool> AddStore(Store store)
        {
            if (store.Id == null || store.Id == 0)
            {
                try
                {
                    string query = "insert into Store(name,address,phone,code) values(@Name,@Address,@Phone,@Code)";
                    await _db.Command(query, new { Name = store.Name,Address=store.Address, Phone = store.Phone, Code = store.Code });
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
                    string query = "update Store set name=@Name,address=@Address,phone=@Phone,code=@Code where id=@Id";
                    await _db.Command(query, store);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> DeleteStore(int id)
        {
            try
            {
                string query = "delete from Store where id = @Id";
                await _db.Command(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Store>> GetStore()
        {
            string query = "select * from Store order by Code desc";
            var result = await _db.Query<Store, dynamic>(query, new { });
            return result;
        }

        //public async Task<Store> GetStoreByCode(string code)
        //{
        //    string query="select "
        //}
    }
}
