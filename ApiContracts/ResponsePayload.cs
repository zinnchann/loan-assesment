namespace LoanAssesmentApi.ApiContracts
{
    public class ResponsePayload
    {
        public string Decision { get; set; }
        public IEnumerable<ResponseRuleValidationResult> ValidationResult { get; set; }
    }

    public class ResponseRuleValidationResult
    {
        public string Rule { get; set; }
        public string Message { get; set; }
        public string Decision { get; set; }
    }
}
