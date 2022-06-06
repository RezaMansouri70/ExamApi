using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Models.UserModels
{
  
    public class AddUserDtoValidation : AbstractValidator<AddUserDto>
    {
        public AddUserDtoValidation()
        {
            RuleFor(c => c.Mobile).NotEmpty().WithMessage("برای موبایل مقدار لازم است")
                .Length(11).WithMessage("موبایل 11 رقم می‌باشد");

            RuleFor(c => c.Password).NotEmpty().WithMessage("برای پسورد مقدار لازم است");
        }
    }
}
