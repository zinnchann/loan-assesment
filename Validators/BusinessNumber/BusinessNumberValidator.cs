namespace LoanAssesmentApi.Validators.BusinessNumber
{
    public class BusinessNumberValidator
    {
        private readonly string _baseUrl = "https://localhost:7001/api/";
        private readonly string _businessNumber;
        public BusinessNumberValidator(string businessNumber)
        {
            _businessNumber= businessNumber;
        }

        public async Task<bool> IsValid()
        {
            HttpClient client = new()
            {
                BaseAddress = new Uri(_baseUrl)
            };
            string requestUrl = $"ExternalService/ValidateBusinessNumber?businessNumber={_businessNumber}";
            var response = await client.GetAsync(requestUrl);

            var result = await response.Content.ReadFromJsonAsync<bool>();

            return result;
        }
    }
}
