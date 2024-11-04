using MediatR;
using System;

namespace Stock.Domain.Models.Product.Update
{
    public class UpdateProductRequestModel : IRequest<Unit>
    {
        public Guid Key { get; set; }

        public string Name { get; set; }
    }
}
