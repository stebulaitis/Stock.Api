using System;

namespace Stock.Domain.Entities
{
    public class Brand : EntityBase
    {
        public Brand()
        {
        }

        public Guid Key { get; private set; }

        public string Name { get; private set; }
    }
}
