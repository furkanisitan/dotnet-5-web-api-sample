using Core.Entities;
using System.Collections.Generic;

namespace Shop.Entities.Concrete
{
    public class Role : IEntity<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
