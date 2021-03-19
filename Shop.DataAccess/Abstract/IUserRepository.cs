using Core.DataAccess;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Abstract
{
    public interface IUserRepository : IRepository<User, int>
    {
    }
}