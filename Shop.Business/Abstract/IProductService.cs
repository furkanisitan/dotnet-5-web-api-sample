using Core.Utilities.ServiceResult;
using Shop.Entities.Concrete;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Shop.Business.Abstract
{
    public interface IProductService
    {
        ICollection<Product> FindAll();
        ICollection<Product> FindAllByCategoryId(int categoryId);
        Product FindById(int id);
        Product FindByName([NotNull] string name);
        ServiceResult Add([NotNull] Product product);
        ServiceResult Update([NotNull] Product product);
        ServiceResult RemoveById(int id);
    }
}