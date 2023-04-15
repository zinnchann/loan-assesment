using LoanAssesmentApi.Constants;
using LoanAssesmentApi.Model;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace LoanAssesmentApi.CustomValidatorAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class TimeTradingAttribute : ValidationAttribute
    {

        public int Minimum { get; set; }
        public int Maximum { get; set; }

        public TimeTradingAttribute()
        {
            this.Minimum = 0;
            this.Maximum = int.MaxValue;
        }

        protected override ValidationResult IsValid(object? value, ValidationContext context)
        {
            int? timeTrading = Convert.ToInt32(value);

            bool isValid = (timeTrading is not null) && timeTrading >= this.Minimum && timeTrading <= this.Maximum;

            if (isValid)
            {
                return ValidationResult.Success;
            }

            var ruleValidationResult = new RuleValidatorResult
            {
                Rule = context.MemberName,
                Message = ErrorMessageFor.TimeTrading,
                Decision = ValidatorDecision.Unknown
            };

            return new ValidationResult(JsonSerializer.Serialize(ruleValidationResult));
        }
    }
}
