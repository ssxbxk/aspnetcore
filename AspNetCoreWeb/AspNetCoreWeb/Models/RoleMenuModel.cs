using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWeb.Models
{
    public class RoleMenuModel
    {
        public Guid RoleId { get; set; }
        public RoleModel Role { get; set; }

        public Guid MenuId { get; set; }
        public MenuModel Menu { get; set; }
    }
}
