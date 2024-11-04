using MediatR;
using System;

namespace Stock.Domain.Models.Product.Get
{
    public class GetProductRequestModel : IRequest<GetProductResponseModel>
    {
        public Guid Key { get; set; }
    }
}
