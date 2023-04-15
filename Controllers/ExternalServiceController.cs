using LoanAssesmentApi.Services.BusinessNumber;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LoanAssesmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExternalServiceController : ControllerBase
    {
        private readonly IBusinessNumberService _businessNumberService;
        public ExternalServiceController(IBusinessNumberService businessNumberService)
        {
            _businessNumberService = businessNumberService;
        }

        [HttpGet("ValidateBusinessNumber")]
        [ResponseCache(Duration = 30, Location = ResponseCacheLocation.Any, VaryByQueryKeys = new string[] { "businessNumber" })]
        public async Task<IActionResult> IsValidBusinessNumber([FromQuery] string businessNumber)
        {
            return Ok(await _businessNumberService.IsValid(businessNumber));
        }
    }
}
