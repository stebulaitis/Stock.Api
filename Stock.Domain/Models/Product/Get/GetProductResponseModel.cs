using System;

namespace Stock.Domain.Models.Product.Get
{
    public class GetProductResponseModel
    {
        public Guid Key { get; set; }

        public string Name { get; set; }

        public bool Active { get; set; }
    }
}
