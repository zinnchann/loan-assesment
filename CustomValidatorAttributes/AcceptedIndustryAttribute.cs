using LoanAssesmentApi.Constants;
using LoanAssesmentApi.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LoanAssesmentApi.CustomValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class AcceptedIndustryAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            string industry = value as string;

            var ruleValidationResult = new RuleValidatorResult
            {
                Rule = context.MemberName,
                Message = ErrorMessageFor.Industry,
                Decision = ValidatorDecision.Unknown
            };

            if (!string.IsNullOrWhiteSpace(industry))
            {
                bool isBannedIndustry = industry.ToUpper().Contains("BANNED");

                if(!isBannedIndustry)
                {
                    return ValidationResult.Success;
                }

                ruleValidationResult.Decision = ValidatorDecision.Unqualified;
            }


            return new ValidationResult(JsonSerializer.Serialize(ruleValidationResult));
        }
    }
}
