using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stock.API.SwaggerExamples;
using Stock.Domain.Contracts.Services;
using Stock.Domain.Models.Product.Add;
using Stock.Domain.Models.Product.Delete;
using Stock.Domain.Models.Product.Get;
using Stock.Domain.Models.Product.Update;
using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Filters;

namespace Stock.API.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ProductsController(
        IProductService service,
        IMediator mediator) : ApiBaseController
    {
        private readonly IProductService _service = service;
        private readonly IMediator _mediator = mediator;

        /// <summary>
        /// Add New Product
        /// </summary>
        /// <param name="command">Request model.</param>
        /// <returns></returns>
        [HttpPost]
        [SwaggerRequestExample(typeof(AddProductRequestModel), typeof(AddProductRequestModelExample))]
        [SwaggerResponse(StatusCodes.Status200OK, "Created Product.", typeof(AddProductResponseModel))]
        public async Task<IActionResult> Post([FromBody] AddProductRequestModel command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        /// <summary>
        /// Get All Products
        /// </summary>
        /// <param name="query"></param>
        /// <returns>All Products Paginated</returns>
        [HttpGet("all")]
        [SwaggerResponse(StatusCodes.Status200OK, "Get All Product.", typeof(GetProductsResponseModel))]
        public async Task<IActionResult> GetProducts([FromQuery] GetProductsRequestModel query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Get Product by Key
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK, "Get Product by Key.", typeof(GetProductResponseModel))]
        public async Task<IActionResult> GetProduct([FromQuery] GetProductRequestModel query)
        {
            var result = await _mediator.Send(query);

            return Ok(result);
        }

        /// <summary>
        /// Alter Product by Key
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [SwaggerRequestExample(typeof(UpdateProductRequestModel), typeof(UpdateProductRequestModelExample))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Put(UpdateProductRequestModel command)
        {
            await _mediator.Send(command);

            return NoContent();
        }

        /// <summary>
        /// Delete Product by Key
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [SwaggerRequestExample(typeof(DeleteProductRequestModel), typeof(DeleteProductRequestModelExample))]
        [SwaggerResponse(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteProduct(DeleteProductRequestModel command)
        {
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
