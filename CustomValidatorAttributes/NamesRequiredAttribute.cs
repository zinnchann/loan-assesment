using LoanAssesmentApi.ApiContracts;
using LoanAssesmentApi.Constants;
using LoanAssesmentApi.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LoanAssesmentApi.CustomValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class NamesRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            var model = (PostPayload)context.ObjectInstance;
            if(!string.IsNullOrWhiteSpace(model.FirstName) || !string.IsNullOrWhiteSpace(model.LastName))
            {
                return ValidationResult.Success;
            }

            var ruleValidationResult = new RuleValidatorResult
            {
                Rule = context.MemberName,
                Message = ErrorMessageFor.Names,
                Decision = ValidatorDecision.Unknown
            };

            return new ValidationResult(JsonSerializer.Serialize(ruleValidationResult));
        }
    }
}
