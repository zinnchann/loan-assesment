namespace LoanAssesmentApi.Model
{
    public class RuleValidatorResult
    {
        public string Rule { get; set; }
        public string Message { get; set; }
        public ValidatorDecision Decision { get; set; }
    }
}
