using MediatR;
using System;

namespace Stock.Domain.Models.Brand.Delete
{
    public class DeleteBrandRequestModel : IRequest<Unit>
    {
        public Guid Key { get; set; }
    }
}
