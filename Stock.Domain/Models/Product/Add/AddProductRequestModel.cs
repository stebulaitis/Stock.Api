using MediatR;

namespace Stock.Domain.Models.Product.Add
{
    public class AddProductRequestModel : IRequest<AddProductResponseModel>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string SKU { get; set; }

        public string EAN { get; set; }

        public int SizeId { get; set; }
    }
}
