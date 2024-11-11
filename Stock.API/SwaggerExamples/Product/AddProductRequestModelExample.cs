using Bogus;
using Stock.Domain.Models.Product.Add;
using Swashbuckle.AspNetCore.Filters;

namespace Stock.API.SwaggerExamples.Product
{
    public class AddProductRequestModelExample : IExamplesProvider<AddProductRequestModel>
    {
        public AddProductRequestModel GetExamples()
        {
            var faker = new Faker();

            return new AddProductRequestModel()
            {
                Name = faker.Commerce.ProductName()
            };
        }
    }
}
