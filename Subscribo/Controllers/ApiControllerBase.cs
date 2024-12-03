using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Subscribo.Core.Abstractions.Models.Responses;

namespace Subscribo.Host.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IActionResult ProcessApiErrorResponse<T>(ApiResponse<T> response)
            => response.Code switch
            {
                Core.Abstractions.Enums.ResponseCode.BadRequest => BadRequest(response.ErrorMessage),
                Core.Abstractions.Enums.ResponseCode.NotFound => NotFound(),
                Core.Abstractions.Enums.ResponseCode.InternalServerError => Problem(),
                _ => throw new NotImplementedException(),
            };
    }
}
