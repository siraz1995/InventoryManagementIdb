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
    public class UnitTypeRepository : IUnitType
    {
        private readonly IDataAccess _db;
        public UnitTypeRepository(IDataAccess db)
        {
            _db = db;
        }
        public async Task<bool> AddUnitType(UnitType unitType)
        {
            if (unitType.Id == null || unitType.Id == 0)
            {
                try
                {
                    string query = "insert into UnitType(name,code) values(@Name,@Code)";
                    await _db.Command(query, new { Name = unitType.Name, Code = unitType.Code });
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
                    string query = "update UnitType set name=@Name,code=@Code where id=@Id";
                    await _db.Command(query, unitType);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }

        public async Task<bool> DeleteUnitType(int id)
        {
            try
            {
                string query = "delete from UnitType where id = @Id";
                await _db.Command(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<UnitType>> GetUnitType()
        {
            string query = "select * from UnitType order by Code desc";
            var result = await _db.Query<UnitType, dynamic>(query, new { });
            return result;
        }
    }
}
