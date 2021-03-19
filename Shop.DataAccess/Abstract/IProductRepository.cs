using Core.DataAccess;
using Shop.Entities.Concrete;

namespace Shop.DataAccess.Abstract
{
    public interface IProductRepository : IRepository<Product, int>
    {
    }
}
