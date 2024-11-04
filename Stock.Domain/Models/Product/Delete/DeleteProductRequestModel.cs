using MediatR;
using System;

namespace Stock.Domain.Models.Product.Delete
{
    public class DeleteProductRequestModel : IRequest<Unit>
    {
        public Guid Key { get; set; }
    }
}
