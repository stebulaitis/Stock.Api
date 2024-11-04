using System;

namespace Stock.Domain.Entities
{
    public class Product : EntityBase
    {
        public Product()
        {
        }

        public Product(string name)
        {
            Key = Guid.NewGuid();
            Name = name;
            Active = true;
        }

        public void Update(string name)
        {
            Name = name;
        }

        public void SetInactive()
        {
            Active = false;
        }

        public  Guid Key { get; private set; }

        public string Name { get; private set; }

        public bool Active { get; private set; }

        

    }
}
