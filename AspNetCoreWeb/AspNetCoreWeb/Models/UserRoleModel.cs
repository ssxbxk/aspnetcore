using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWeb.Models
{
    public class UserRoleModel
    {
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        public Guid RoleId { get; set; }
        public RoleModel Role { get; set; }
    }
}
