using Core.Entities;
using System.Collections.Generic;

namespace Shop.Entities.Concrete
{
    public class Category : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
