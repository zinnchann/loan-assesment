using LoanAssesmentApi.Constants;
using LoanAssesmentApi.Model;
using LoanAssesmentApi.Validators.BusinessNumber;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LoanAssesmentApi.CustomValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class BusinessNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            string businessNumber = value as string;

            var ruleValidationResult = new RuleValidatorResult
            {
                Rule = context.MemberName,
                Message = ErrorMessageFor.BusinessNumber,
                Decision = ValidatorDecision.Unknown
            };

            if (!string.IsNullOrEmpty(businessNumber))
            {

                var businessValidator = new BusinessNumberValidator(businessNumber);

                bool isValid = businessValidator.IsValid().GetAwaiter().GetResult();
                if (isValid)
                {
                    return ValidationResult.Success;
                }

                ruleValidationResult.Decision = ValidatorDecision.Unqualified;
            }

            return new ValidationResult(JsonSerializer.Serialize(ruleValidationResult));
        }
    }
}
