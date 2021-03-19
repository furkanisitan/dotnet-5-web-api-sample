using Core.DataAccess;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Abstract
{
    public interface IRoleRepository : IRepository<Role, int>
    {
    }
}