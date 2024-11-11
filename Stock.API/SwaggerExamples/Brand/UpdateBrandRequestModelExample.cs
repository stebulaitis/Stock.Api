using Bogus;
using Stock.Domain.Models.Brand.Update;
using Swashbuckle.AspNetCore.Filters;

namespace Stock.API.SwaggerExamples.Brand
{
    public class UpdateBrandRequestModelExample : IExamplesProvider<UpdateBrandRequestModel>
    {
        public UpdateBrandRequestModel GetExamples()
        {
            var faker = new Faker();

            return new UpdateBrandRequestModel()
            {
                Key = Guid.NewGuid(),
                Name = faker.Company.CompanyName()
            };
        }
    }
}
