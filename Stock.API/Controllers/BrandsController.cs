using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stock.API.SwaggerExamples.Brand;
using Stock.Domain.Models.Brand.Add;
using Stock.Domain.Models.Brand.Delete;
using Stock.Domain.Models.Brand.Get;
using Stock.Domain.Models.Brand.Update;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Stock.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class BrandsController(IMediator mediator) : ApiBaseController
    {
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Add New Brand
        /// </summary>
        /// <param name="command">Request model.</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(AddBrandRequestModel), typeof(AddBrandRequestModelExample))]
        [SwaggerResponse(StatusCodes.Status200OK, "Created Brand.", typeof(AddBrandResponseModel))]
        public async Task<IActionResult> Post([FromBody] AddBrandRequestModel command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// Get All Brands
        /// </summary>
        /// <param name="query"></param>
        /// <returns>All Brands Paginated</returns>
        [HttpGet("all")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get All Brand.", typeof(GetBrandsResponseModel))]
        public async Task<IActionResult> GetBrands([FromQuery] GetBrandsRequestModel query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Get Brand by Key
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Brand by Key.", typeof(GetBrandResponseModel))]
        public async Task<IActionResult> GetBrand([FromQuery] GetBrandRequestModel query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Alter Brand by Key
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerRequestExample(typeof(UpdateBrandRequestModel), typeof(UpdateBrandRequestModelExample))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(UpdateBrandRequestModel command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete Brand by Key
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [SwaggerRequestExample(typeof(DeleteBrandRequestModel), typeof(DeleteBrandRequestModelExample))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(DeleteBrandRequestModel command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
