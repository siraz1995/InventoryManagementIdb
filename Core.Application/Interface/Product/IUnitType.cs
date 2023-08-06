using Core.Domain.BasicInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Product
{
    public interface IUnitType
    {
        Task<bool> AddUnitType(UnitType unitType);
        Task<IEnumerable<UnitType>> GetUnitType();
        Task<bool> DeleteUnitType(int id);
    }
}
