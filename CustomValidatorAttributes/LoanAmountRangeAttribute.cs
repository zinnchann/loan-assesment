using LoanAssesmentApi.Constants;
using LoanAssesmentApi.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LoanAssesmentApi.CustomValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class LoanAmountRangeAttribute : ValidationAttribute
    {
        public double Minimum { get; set; }
        public double Maximum { get; set; }
        public LoanAmountRangeAttribute()
        {
            this.Minimum = 0;
            this.Maximum = double.MaxValue;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            double? amount = Convert.ToDouble(value);

            bool isValid = (amount is not null) && amount >= this.Minimum && amount <= this.Maximum;

            if(isValid)
            {
                return ValidationResult.Success;
            }

            var ruleValidationResult = new RuleValidatorResult
            {
                Rule = context.MemberName,
                Message = ErrorMessageFor.LoanAmount,
                Decision = ValidatorDecision.Unknown
            };

            return new ValidationResult(JsonSerializer.Serialize(ruleValidationResult));
        }
    }
}
