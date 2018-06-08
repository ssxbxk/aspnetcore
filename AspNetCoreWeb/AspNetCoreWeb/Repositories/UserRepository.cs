
using System.Linq;
using AspNetCoreWeb.Models;
using AspNetCoreWeb.IRepositories;
using AspNetCoreWeb.Data;

namespace AspNetCoreWeb.Repositories
{
    /// <summary>
    /// 用户管理仓储实现
    /// </summary>
    public class UserRepository : FonourRepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(FonourDbContext dbcontext) : base(dbcontext)
        {

        }
        /// <summary>
        /// 检查用户是存在
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>存在返回用户实体，否则返回NULL</returns>
        public UserModel CheckUser(string userName, string password)
        {
            return _dbContext.Set<UserModel>()
                .FirstOrDefault(it => it.UserName == userName && it.Password == password);
        }
    }
}
