
using LoanAssesmentApi.Constants;
using LoanAssesmentApi.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LoanAssesmentApi.CustomValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AcceptedCountryCodeAttribute : ValidationAttribute
    {
        public string CountryCode { get; set; }
        public AcceptedCountryCodeAttribute()
        {
            CountryCode = CountryCodes.Australia;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            string countryCode = value as string;
            bool isValid = countryCode is not null && (countryCode.ToUpper() == CountryCode.ToUpper());

            if(isValid)
            {
                return ValidationResult.Success;
            }

            var ruleValidationResult = new RuleValidatorResult
            {
                Rule = context.MemberName,
                Message = ErrorMessageFor.CountryCode,
                Decision = ValidatorDecision.Unknown
            };

            return new ValidationResult(JsonSerializer.Serialize(ruleValidationResult));
        }
    }
}
