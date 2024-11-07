using Stock.Domain.Contracts.Storage;
using System;

namespace Stock.Domain.Entities
{
    public class Size : IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }
    }
}
