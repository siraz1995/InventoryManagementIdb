using Core.Domain.Procurement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public interface IDataAccess
    {
        Task<IEnumerable<T>> Query<T, P>(string query, P parameters,string connectionId = "default");
        Task Command<P>(string query, P parameters, string connectionId = "default");

        Task<IEnumerable<T>> QueryAsync<T, P>(string query, P parameters,string connectionId = "purchaseOrder");
        Task CommandAsync<P>(string query, P parameters, string connectionId = "purchaseOrder");

    }
}
