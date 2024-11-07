using System;

namespace Stock.Domain.Models.Product.Get
{
    public class GetProductResponseModel
    {
        public Guid Key { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string SKU { get; set; }

        public string EAN { get; set; }

        public string Size { get; set; }

        public bool Active { get; set; }
    }
}
