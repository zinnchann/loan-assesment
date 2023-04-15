using LoanAssesmentApi.Constants;
using LoanAssesmentApi.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LoanAssesmentApi.CustomValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class CitizenshipStatusAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            string citizenshipStatus = value as string;
            if (!string.IsNullOrWhiteSpace(citizenshipStatus))
            {
                citizenshipStatus = citizenshipStatus.Replace(" ", "");
                bool isValid = Enum.TryParse(citizenshipStatus, out CitizenshipStatus decision);

                if(isValid)
                {
                   return ValidationResult.Success;
                }
            }

            var ruleValidationResult = new RuleValidatorResult
            {
                Rule = context.MemberName,
                Message = ErrorMessageFor.CitizenshipStatus,
                Decision = ValidatorDecision.Unknown
            };

            return new ValidationResult(JsonSerializer.Serialize(ruleValidationResult));
        }
    }
}
