using LoanAssesmentApi.ApiContracts;
using LoanAssesmentApi.Constants;
using LoanAssesmentApi.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LoanAssesmentApi.CustomValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ContactsRequiredAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext context)
        {
            var model = (PostPayload)context.ObjectInstance;
            if (!string.IsNullOrWhiteSpace(model.EmailAddress) || !string.IsNullOrWhiteSpace(model.PhoneNumber))
            {
                return ValidationResult.Success;
            }

            var ruleValidationResult = new RuleValidatorResult
            {
                Rule = context.MemberName,
                Message = ErrorMessageFor.Contacts,
                Decision = ValidatorDecision.Unknown
            };

            return new ValidationResult(JsonSerializer.Serialize(ruleValidationResult));
        }
    }
}
