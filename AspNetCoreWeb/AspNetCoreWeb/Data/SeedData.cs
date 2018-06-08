using System;
using System.Linq;
using AspNetCoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWeb.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider, String dbString)
        {
            var opt = new DbContextOptionsBuilder<FonourDbContext>()
                .UseNpgsql(dbString).Options;

            using (var context = new FonourDbContext(opt))
            {
                if (context.Users.Any())
                    return;

                Guid dId = Guid.NewGuid();
                context.Departments.Add(
                    new DepartmentModel {
                        Id = dId,
                        Name = "总部",
                        ParentId = Guid.Empty
                    }
                );

                Guid roleGUID = Guid.NewGuid();
                context.Roles.Add(
                    new RoleModel
                    {
                        Id = roleGUID,
                        Code = "RCode",
                        Name = "管理员角色",
                        CreateTime = DateTime.Now
                    }
                );

                context.Users.Add(
                    new UserModel {
                        Id = Guid.NewGuid(),
                        UserName = "admin",
                        Password = "1",
                        Name = "管理员",
                        DepartmentId = dId,
                        RoleId = roleGUID
                    }
                );

                context.Menus.AddRange(
                    new MenuModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "组织机构管理",
                        Code = "Department",
                        SerialNumber = 0,
                        ParentId = Guid.Empty,
                        Icon = "fa fa-link"
                    },
                    new MenuModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "角色管理",
                        Code = "Role",
                        SerialNumber = 1,
                        ParentId = Guid.Empty,
                        Icon = "fa fa-link"
                    },
                    new MenuModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "用户管理",
                        Code = "User",
                        SerialNumber = 2,
                        ParentId = Guid.Empty,
                        Icon = "fa fa-link"
                    },
                    new MenuModel
                    {
                        Id = Guid.NewGuid(),
                        Name = "功能管理",
                        Code = "Department",
                        SerialNumber = 3,
                        ParentId = Guid.Empty,
                        Icon = "fa fa-link"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
