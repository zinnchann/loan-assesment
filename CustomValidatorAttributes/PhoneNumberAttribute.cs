using LoanAssesmentApi.Constants;
using LoanAssesmentApi.Model;
using LoanAssesmentApi.Validators.PhoneNumber;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LoanAssesmentApi.CustomValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberAttribute : ValidationAttribute
    {
        public string CountryCode { get; set; }
        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            string phoneNumber = value as string;
            if(!string.IsNullOrEmpty(phoneNumber))
            {

                ICountryPhoneNumberValidator countryPhoneNumberValidator = CountryCode.ToUpper() switch
                {
                    CountryCodes.Australia => new AustraliaPhoneNumberValidator(phoneNumber),
                    _ => new AustraliaPhoneNumberValidator(phoneNumber)
                };

                if(countryPhoneNumberValidator.IsValid())
                {
                    return ValidationResult.Success;
                }

                var ruleValidationResult = new RuleValidatorResult
                {
                    Rule = context.MemberName,
                    Message = ErrorMessageFor.PhoneNumberFormat,
                    Decision = ValidatorDecision.Unknown
                };

                return new ValidationResult(JsonSerializer.Serialize(ruleValidationResult));
            }

            return ValidationResult.Success;
        }
    }
}
