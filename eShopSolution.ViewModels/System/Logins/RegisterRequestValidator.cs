using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.ViewModels.System.Logins
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            //không cho phép rỗng, nếu rỗng trả về WithMessge (thông báo)   
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("FirstName is Required")
                .MaximumLength(200).WithMessage("First Name can not over 200 characters");

            RuleFor(x => x.LastName).NotEmpty().WithMessage("LastName is Required").
                MaximumLength(200).WithMessage("Last Name can not over 200 characters");

            RuleFor(x => x.Dob).GreaterThan(DateTime.Now.AddYears(-100))
                .WithMessage("Birthday cannot greater than 100 years");

            RuleFor(x => x.Email).NotEmpty().WithMessage("Email is required")
                .Matches(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")
                .WithMessage("Email format not match");

            RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage("Number Phone is required");
            //.Matches(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}").WithMessage("Number phone format not match ");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password is at  least 6 characters ");
            RuleFor(x => x).Custom((request, Context) =>
            {
                if (request.Password != request.ConfirmPassword)
                {
                    Context.AddFailure("Confirm password is not match");
                }
            }); 
        }
    }
}
