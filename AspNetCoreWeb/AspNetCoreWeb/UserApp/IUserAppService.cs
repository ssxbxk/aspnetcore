using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreWeb.Models;

namespace AspNetCoreWeb.UserApp
{
    public interface IUserAppService
    {
        UserModel CheckUser(string userName, string password);
    }
}
