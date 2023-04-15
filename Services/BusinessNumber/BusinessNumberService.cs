namespace LoanAssesmentApi.Services.BusinessNumber
{
    public class BusinessNumberService : IBusinessNumberService
    {
        public async Task<bool> IsValid(string businessNumber)
        {
            bool result = businessNumber.Length == 11;
            await Task.Delay(2000);
            return result;
        }
    }
}
