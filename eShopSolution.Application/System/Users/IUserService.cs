using eShopSolution.ViewModels.System;
using eShopSolution.ViewModels.System.Logins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.System.Users
{
    public interface IUserService
    {
        // Tạo ra 1 Task<> chả về có đăng nhập đc hay không
        Task<string> Authencate(LoginRequest request);
        Task<bool> Register(RegisterRequest request);
    }
}
