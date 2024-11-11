using Bogus;
using Stock.Domain.Models.Brand.Delete;
using Swashbuckle.AspNetCore.Filters;

namespace Stock.API.SwaggerExamples.Brand
{
    public class DeleteBrandRequestModelExample : IExamplesProvider<DeleteBrandRequestModel>
    {
        public DeleteBrandRequestModel GetExamples()
        {
            var faker = new Faker();

            return new DeleteBrandRequestModel()
            {
                Key = Guid.NewGuid()
            };
        }
    }
}
