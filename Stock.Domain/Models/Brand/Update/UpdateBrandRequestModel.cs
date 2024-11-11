using MediatR;
using System;

namespace Stock.Domain.Models.Brand.Update
{
    public class UpdateBrandRequestModel : IRequest<Unit>
    {
        public Guid Key { get; set; }

        public string Name { get; set; }
    }
}
