using FluentValidation;

namespace Mycar.Common.Extensions
{
    public static class CustomValidators
    {
        public static IRuleBuilderOptions<T, string> ValidVIN<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty()
                .WithMessage("VIN is required.")
                .Must(BeAValidVIN)
                .WithMessage("Invalid VIN format.");
        }

        private static bool BeAValidVIN(string vin)
        {
            return !string.IsNullOrWhiteSpace(vin) && vin.Length == 17;
        }
    }
}
