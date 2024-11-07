using MediatR;
using System;

namespace Stock.Domain.Models.Product.Update
{
    public class UpdateProductRequestModel : IRequest<Unit>
    {
        public Guid Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BrandId { get; set; }

        public string SKU { get; set; }

        public string EAN { get; set; }

        public int SizeId { get; set; }
    }
}
