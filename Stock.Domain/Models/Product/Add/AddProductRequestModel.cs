using MediatR;

namespace Stock.Domain.Models.Product.Add
{
    public class AddProductRequestModel : IRequest<AddProductResponseModel>
    {
        public string Name { get; set; }
    }
}
