using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Models.UserExam
{
   
    public class AddUserExamDtoValidation : AbstractValidator<AddUserExamDto>
    {
        public AddUserExamDtoValidation()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("برای نام آزمون مقدار لازم است")
                .MaximumLength(1000).WithMessage("طول نام آزمون حدکثر 1000 کاراکتر می‌باشد");
        }
    }
}
