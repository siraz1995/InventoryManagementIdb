using Core.Application.Interface.Procurment;
using Core.Application.Interface.Product;
using Core.Domain.BasicInfo;
using Core.Domain.Procurement;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Procurment
{
    public class SupplierRepository : ISupplier
    {
        private readonly IDataAccess _db;
        public SupplierRepository(IDataAccess db)
        {
            _db = db;
        }
        public async Task<Supplier> AddSupplier(Supplier supplier)
        {
            if (supplier.Id == null || supplier.Id == 0)
            {
                try
                {
                    string query = "insert into Supplier(name,address,email,phone,code) values(@Name,@Address,@Email,@Phone,@Code)";
                    await _db.Command(query, new { Name = supplier.Name, Address = supplier.Address,Email=supplier.Email, Phone = supplier.Phone, Code = supplier.Code });
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Occur");
                }
            }
            else
            {
                try
                {
                    string query = "update Supplier set name=@Name,address=@Address,email=@Email,phone=@Phone,code=@Code where id=@Id";
                    await _db.Command(query, supplier);
                }
                catch (Exception ex)
                {
                    throw new Exception("Error Occur");
                }
            }
            return supplier;
        }

        public async Task<bool> DeleteSupplier(int id)
        {
            try
            {
                string query = "delete from Supplier where id = @Id";
                await _db.Command(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Supplier>> GeSupplier()
        {
            string query = "select * from Supplier order by Code desc";
            var result = await _db.Query<Supplier, dynamic>(query, new { });
            return result;
        }
    }
}
