using Core.Application.Interface.Authentication;
using Core.Domain.Authentication;
using Core.Domain.Brand;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository.Authentication
{
    public class AuthenticationRepository : IAuthentication
    {
        private readonly IDataAccess _db;
        public AuthenticationRepository(IDataAccess db)
        {
            _db = db;
        }


        public async Task<List<Registration>> GetUserByUserName(string userName)
        {
            string query = $@"Select * from [InventorymanagementSyatem].[dbo].[Registration] where userName=@UserName";
            List<Registration> reg= (List<Registration>)await _db.Query<Registration,dynamic>(query, new { UserName= userName});
            return reg.ToList();

        }
        public async Task<List<Registration>> GetUserById(int id)
        {
            string query = $@"Select * from [InventorymanagementSyatem].[dbo].[Registration] where id=@id";
            List<Registration> reg = (List<Registration>)await _db.Query<Registration, dynamic>(query, new { id = id });
            return reg.ToList();
        }
        public async Task<bool> SaveRegistrationForm(Registration model)
        {
            if(model.Id==null || model.Id == 0)
            {
                string query = $@"Insert into [InventorymanagementSyatem].[dbo].[Registration](UserName,FullName,EmailAddress,Password,Gender,Role,IsActive)Values(@UserName,@FullName,@EmailAddress,@Password,@Gender,@Role,@IsActive)";
                await _db.Command(query, new { 
                                                UserName        = model.UserName,
                                                FullName        = model.FullName,
                                                EmailAddress    = model.EmailAddress,
                                                Password        = model.Password,
                                                Gender          = model.Gender,
                                                Role            = model.Role,
                                                IsActive        = model.IsActive, 
                                            });
            }
            else
            {
                string query = $@"update [InventorymanagementSyatem].[dbo].[Registration] set fullName=@FullName,emailAddress=@EmailAddress,password=@Password where id=@Id";
                await _db.Command(query, model);
            }
            return true;
        }

        public async Task<bool> SaveRole(Role model)
        {
            if (model.Id == null || model.Id == 0)
            {
                string query = $@"Insert into [InventorymanagementSyatem].[dbo].[Role](Name,Code)Values(@Name,@Code)";
                await _db.Command(query, new
                {
                    Name = model.Name,
                    Code = model.Code,
                });
            }
            else
            {
                try
                {
                    string query = "update [InventorymanagementSyatem].[dbo].[Role] set name=@Name,code=@Code where id=@Id";
                    await _db.Command(query, model);
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
            return true;
        }
        public async Task<List<Role>> GetRole()
        {
            string query = $@"Select * from [InventorymanagementSyatem].[dbo].[Role] Order by Code Desc";
            List<Role> role = (List<Role>)await _db.Query<Role, dynamic>(query, new { });
            return role.ToList();
        }
        public async Task<bool> DeleteRole(int id)
        {
            try
            {
                string query = "delete from [InventorymanagementSyatem].[dbo].[Role] where id = @Id";
                await _db.Command(query, new { Id = id });
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<Registration>> GetRegisterUser()
        {
            string query = $@"Select * from [InventorymanagementSyatem].[dbo].[Registration]";
            List<Registration> role = (List<Registration>)await _db.Query<Registration, dynamic>(query, new { });
            return role.ToList();
        }

    }
}
