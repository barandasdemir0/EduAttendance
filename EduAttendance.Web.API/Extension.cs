using FluentValidation;
using FluentValidation.Validators;

namespace EduAttendance.Web.API
{
    public static class Extension
    {
        //public static string ToUpperBaran(this string str) 
        //{
        //    return "Baran";
        //}
        public static IRuleBuilderOptions<T, string> CheckIdentityNumber<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new IdentityCheckValidator<T>());
        }
    }

    // TC Kimlik No Validator
    public class IdentityCheckValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "IdentityNumberValidator";

        public override bool IsValid(ValidationContext<T> context, string value)
        {
            if (string.IsNullOrWhiteSpace(value)) return false;
            value = value.Trim();

            // 11 hane ve tümü rakam olmalı
            if (value.Length != 11 || !value.All(char.IsDigit)) return false;

            // İlk hane 0 olamaz
            if (value[0] == '0') return false;

            // Tüm hanesi aynı olan numaraları ele (örn. 11111111111)
            if (value.Distinct().Count() == 1) return false;

            int[] d = value.Select(c => c - '0').ToArray();

            // 1.,3.,5.,7.,9. hanelerin toplamı
            int sumOdd = d[0] + d[2] + d[4] + d[6] + d[8];

            // 2.,4.,6.,8. hanelerin toplamı
            int sumEven = d[1] + d[3] + d[5] + d[7];

            // 10. hane kontrolü
            int digit10 = ((sumOdd * 7) - sumEven) % 10;
            if (digit10 < 0) digit10 += 10;
            if (d[9] != digit10) return false;

            // 11. hane kontrolü
            int digit11 = (d.Take(10).Sum()) % 10;
            if (d[10] != digit11) return false;

            return true;
        }

        protected override string GetDefaultMessageTemplate(string errorCode)
            => "{PropertyName} geçerli bir TC Kimlik numarası olmalıdır.";
    }
}

