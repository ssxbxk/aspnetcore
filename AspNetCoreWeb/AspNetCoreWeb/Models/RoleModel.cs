using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWeb.Models
{
    public class RoleModel
    {
        [Key]
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public Guid CreateUserId { get; set; }

        public DateTime? CreateTime { get; set; }

        public string Remarks { get; set; }

        public virtual ICollection<UserModel> Users { get; set; }

        public virtual ICollection<MenuModel> Menus { get; set; }

        public virtual ICollection<RoleMenuModel> RoleMenus { get; set; }

    }
}
