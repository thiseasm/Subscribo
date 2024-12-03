using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Subscribo.Core.Abstractions.Interfaces.Managers;
using Subscribo.Core.Abstractions.Models.Requests;
using Subscribo.Host.WebApi.Controllers;

namespace Subscribo.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController(ICustomerManager customerManager) : ApiControllerBase
    {
        [HttpGet]
        [Route("{customerId:int}")]
        public async Task<IActionResult> GetByIdAsync(int customerId, CancellationToken cancellationToken = default)
        {
            var result = await customerManager.GetByIdAsync(customerId, cancellationToken);
            if (result.IsSuccess)
            { 
                return Ok(result.Value);
            }

            return ProcessApiErrorResponse(result);
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CreateCustomerAsync(CreateCustomerRequest request, CancellationToken cancellationToken = default)
        {
            var result = await customerManager.CreateCustomerAsync(request, cancellationToken);
            if (result.IsSuccess)
            {
                return Created(default(string), result.Value);
            }

            return ProcessApiErrorResponse(result);
        }
    }
}
