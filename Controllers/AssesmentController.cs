using LoanAssesmentApi.ApiContracts;
using LoanAssesmentApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json;

namespace LoanAssesmentApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssesmentController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] PostPayload payload)
        {
            var response = new ResponsePayload();

            if(!ModelState.IsValid)
            {
                response.Decision = nameof(ValidatorDecision.Unqualified);
                response.ValidationResult = TransformValidationError(ModelState);
                return BadRequest(response);
            }

            response.Decision = nameof(ValidatorDecision.Qualified);
            return Ok(response);
        }

        private IEnumerable<ResponseRuleValidationResult> TransformValidationError(ModelStateDictionary modelState)
        {
            List<ResponseRuleValidationResult> transformedResult = new();
            var modelStateErrors = modelState.Values.Select(s => s.Errors).ToList();

            foreach(var state in modelState)
            {
                foreach(var error in state.Value.Errors)
                {
                    var obj = JsonSerializer.Deserialize<RuleValidatorResult>(error.ErrorMessage);

                    ResponseRuleValidationResult responseRuleValidationResult = new()
                    {
                        Rule = obj.Rule,
                        Message = obj.Message,
                        Decision = obj.Decision.ToString(),
                    };
                    transformedResult.Add(responseRuleValidationResult);
                }
            }

            return transformedResult;
        }
    }
}
