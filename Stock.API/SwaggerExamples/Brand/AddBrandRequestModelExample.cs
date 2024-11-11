using Bogus;
using Stock.Domain.Models.Brand.Add;
using Swashbuckle.AspNetCore.Filters;

namespace Stock.API.SwaggerExamples.Brand
{
    public class AddBrandRequestModelExample : IExamplesProvider<AddBrandRequestModel>
    {
        public AddBrandRequestModel GetExamples()
        {
            var faker = new Faker();

            return new AddBrandRequestModel()
            {
                Name = faker.Company.CompanyName()
            };
        }
    }
}
