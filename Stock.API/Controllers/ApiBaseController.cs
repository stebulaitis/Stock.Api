using Microsoft.AspNetCore.Mvc;
using Stock.Core.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Stock.API.Controllers
{
    [ApiController]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "This error occurs when a domain exception is thrown", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "This error occurs when a data not found exception is thrown", typeof(ErrorResponse))]
    [SwaggerResponse(StatusCodes.Status500InternalServerError, "Internal error occurred while processing the request", typeof(ErrorResponse))]
    public class ApiBaseController : ControllerBase
    {
    }
}
