namespace LoanAssesmentApi.Services.BusinessNumber
{
    public interface IBusinessNumberService
    {
        Task<bool> IsValid(string businessNumber);
    }
}
