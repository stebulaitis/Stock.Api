using Bogus;
using Stock.Domain.Models.Product.Delete;
using Swashbuckle.AspNetCore.Filters;

namespace Stock.API.SwaggerExamples.Product
{
    public class DeleteProductRequestModelExample : IExamplesProvider<DeleteProductRequestModel>
    {
        public DeleteProductRequestModel GetExamples()
        {
            var faker = new Faker();

            return new DeleteProductRequestModel()
            {
                Key = Guid.NewGuid()
            };
        }
    }
}
