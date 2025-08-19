using EduAttendance.Web.API.Dtos;
using FluentValidation;

namespace EduAttendance.Web.API.Validators
{
    public class CreateStudenValidator:AbstractValidator<CreateStudenDto>
    {
        public CreateStudenValidator()
        {
           

            RuleFor(p => p.FirstName).MinimumLength(3).WithMessage("Ad en az 3 karakter olmalıdır");


            RuleFor(p => p.LastName).MinimumLength(3).WithMessage("Soyad en az 3 karakter olmalıdır");

            RuleFor(p => p.PhoneNumber).MinimumLength(10).WithMessage("Telefon numarası 10 karakter olmalıdır").MaximumLength(18).WithMessage("Telefon numarası 10 karakter olmalıdır");

            RuleFor(p => p.Email).EmailAddress().WithMessage("Geçerli bir mail adresi girin");

            RuleFor(p => p.IdentityNumber).MinimumLength(11).WithMessage("TC numarası 11 karakter olmalıdır").MaximumLength(11).WithMessage("TC numarası 11 karakter olmalıdır").CheckIdentityNumber().WithMessage("Geçerli bir TC Numarası girin");


        }


        public static bool TCKimlikNoDogrula(string tc)
        {
            if (string.IsNullOrEmpty(tc) || tc.Length != 11)
                return false;

            if (!long.TryParse(tc, out _)) // Sadece rakam mı kontrol et
                return false;

            if (tc[0] == '0') // İlk hane 0 olamaz
                return false;

            int[] haneler = tc.Select(ch => int.Parse(ch.ToString())).ToArray();

            int tekToplam = haneler[0] + haneler[2] + haneler[4] + haneler[6] + haneler[8];
            int ciftToplam = haneler[1] + haneler[3] + haneler[5] + haneler[7];

            int hane10 = ((tekToplam * 7) - ciftToplam) % 10;
            if (haneler[9] != hane10)
                return false;

            int hane11 = (haneler.Take(10).Sum()) % 10;
            if (haneler[10] != hane11)
                return false;

            return true;
        }

    }
}
