using EduAttendance.Web.API.Dtos;
using FluentValidation;

namespace EduAttendance.Web.API.Validators
{
    public class UpdateStudentValidator : AbstractValidator<UpdateStudenDto>
    {
        public UpdateStudentValidator()
        {


            RuleFor(p => p.FirstName).MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır");


            RuleFor(p => p.LastName).MinimumLength(3).WithMessage("Soyad en az 3 karakter olmalıdır");

            RuleFor(p => p.PhoneNumber).MinimumLength(10).WithMessage("Telefon numarası 10 karakter olmalıdır").MaximumLength(18).WithMessage("Telefon numarası 10 karakter olmalıdır");

            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi girin");

            RuleFor(p => p.IdentityNumber).MinimumLength(11).WithMessage("TC numarası 11 karakter olmalıdır").MaximumLength(11).WithMessage("TC numarası 11 karakter olmalıdır").CheckIdentityNumber().WithMessage("Geçerli bir TC Numarası girin");


        }
    }
}
