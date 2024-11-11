using MediatR;

namespace Stock.Domain.Models.Brand.Add
{
    public class AddBrandRequestModel : IRequest<AddBrandResponseModel>
    {
        public string Name { get; set; }
    }
}
