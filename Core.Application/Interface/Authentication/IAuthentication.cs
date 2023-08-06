using Core.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.Interface.Authentication
{
    public interface IAuthentication
    {
        Task<bool> SaveRegistrationForm(Registration model);
        Task<List<Registration>> GetUserByUserName(string userName);
        Task<List<Registration>> GetUserById(int id);
        Task<List<Registration>> GetRegisterUser();
        Task<bool> SaveRole(Role model);
        Task<List<Role>> GetRole();
        Task<bool> DeleteRole(int id);

    }
}
