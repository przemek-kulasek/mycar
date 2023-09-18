using FluentValidation;

namespace Mycar.Common.Extensions
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> ValidVin<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage("VIN is required.")
                .Must(BeAValidVin)
                .WithMessage("Invalid VIN format.");
        }

        private static bool BeAValidVin(string vin)
        {
            return !string.IsNullOrWhiteSpace(vin) && vin.Length == 17;
        }
    }
}
