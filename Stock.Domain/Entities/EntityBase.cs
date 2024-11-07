using Stock.Domain.Contracts.Storage;
using System;

namespace Stock.Domain.Entities
{
    public class EntityBase : IEntity
    {
        public int Id { get; set; }

        public bool Active { get; set; } = true;

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
