using Bogus;
using Stock.Domain.Models.Product.Update;
using Swashbuckle.AspNetCore.Filters;

namespace Stock.API.SwaggerExamples
{
    public class UpdateProductRequestModelExample : IExamplesProvider<UpdateProductRequestModel>
    {
        public UpdateProductRequestModel GetExamples()
        {
            var faker = new Faker();

            return new UpdateProductRequestModel()
            {
                Key = Guid.NewGuid(),
                Name = faker.Commerce.ProductName()
            };
        }
    }
}
