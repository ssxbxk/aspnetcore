using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreWeb.Data
{
    public class FonourDbContext : DbContext
    {
        public FonourDbContext(DbContextOptions<FonourDbContext> options) : base(options)
        {

        }
        public DbSet<DepartmentModel> Departments { get; set; }
        public DbSet<MenuModel> Menus { get; set; }
        public DbSet<RoleModel> Roles { get; set; }
        public DbSet<UserModel> Users { get; set; }
        public DbSet<UserRoleModel> UserRoles { get; set; }
        public DbSet<RoleMenuModel> RoleMenus { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<DepartmentModel>()
                .HasMany(dm => dm.Users)
                .WithOne(p => p.DepartmentModel)
                .HasForeignKey(d => d.DepartmentId);

            builder.Entity<RoleModel>()
                .HasMany(dm => dm.Users)
                .WithOne(p => p.RoleModel)
                .HasForeignKey(d => d.RoleId);

            //UserRole关联配置
            builder.Entity<UserRoleModel>()
              .HasKey(ur => new { ur.UserId, ur.RoleId });

            //RoleMenu关联配置
            builder.Entity<RoleMenuModel>()
              .HasKey(rm => new { rm.RoleId, rm.MenuId });

            builder.Entity<RoleMenuModel>()
              .HasOne(rm => rm.Role)
              .WithMany(r => r.RoleMenus)
              .HasForeignKey(rm => rm.RoleId).HasForeignKey(rm => rm.MenuId);

            //启用Guid主键类型扩展
            builder.HasPostgresExtension("uuid-ossp");

            base.OnModelCreating(builder);
        }
    }
}
