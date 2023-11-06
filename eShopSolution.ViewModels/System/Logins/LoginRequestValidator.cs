using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.System.Logins
{
    public class LoginRequestValidator : AbstractValidator<LoginRequest>
    {
        public LoginRequestValidator() 
        {
            //không cho phép rỗng, nếu rỗng trả về WithMessge (thông báo)
            RuleFor(x => x.Username).NotEmpty().WithMessage("User name is required");
            RuleFor(x => x.Password).NotEmpty()
                .MinimumLength(6).WithMessage("Password is at least 6 charecters");
        }
    }
}
