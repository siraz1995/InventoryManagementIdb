using Core.Domain.Stock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Item_Stock
{
    public interface IStockRepository
    {
        Task<List<ItemStock>> GetStockItem();
    }
}
