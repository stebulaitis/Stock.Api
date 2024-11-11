using System;

namespace Stock.Domain.Entities
{
    public class Brand : EntityBase
    {
        public Brand()
        {
        }

        public Brand(string name)
        {
            Key = Guid.NewGuid();
            Name = name;
        }

        public void Update(string name)
        {
            Name = name;
        }

        public void SetStatus(bool active)
        {
            Active = active;
        }

        public Guid Key { get; private set; }

        public string Name { get; private set; }
    }
}
