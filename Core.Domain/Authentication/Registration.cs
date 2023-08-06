using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Domain.Authentication
{
    public class Registration
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        public string Gender { get; set; }
        public string Role { get; set; }
        public bool IsActive { get; set; }
        public int ActiveUser { get; set; }
        public int InActiveUser { get; set; }
    }
}
