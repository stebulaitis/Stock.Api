using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Stock.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
        }

        public Product(string name, string description, int brandId, string sku, string ean, int sizeId)
        {
            Key = Guid.NewGuid();
            Name = name;
            Description = description;
            BrandId = brandId;
            SKU = sku ?? string.Concat(this.Name.AsSpan(1, 2), "-");
            EAN = ean;
            SizeId = sizeId;
        }

        public void Update(string name, string description, int brandId, string sku, string ean, int sizeId)
        {
            Name = name;
            Description = description;
            BrandId = brandId;
            SKU = sku;
            EAN = ean;
            SizeId = sizeId;
        }

        public void SetStatus(bool active)
        {
            Active = active;
        }

        public Guid Key { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public int SizeId { get; set; }

        public int BrandId { get; private set; }

        public string SKU { get; private set; }

        public string EAN { get; private set; }

        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }

        [ForeignKey("SizeId")]
        public virtual Size Size { get; set; }
    }
}
