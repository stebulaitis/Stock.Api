using MediatR;
using System;

namespace Stock.Domain.Models.Brand.Get
{
    public class GetBrandRequestModel : IRequest<GetBrandResponseModel>
    {
        public Guid Key { get; set; }
    }
}
