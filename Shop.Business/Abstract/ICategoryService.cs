using Core.Utilities.ServiceResult;
using Shop.Entities.Concrete;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Shop.Business.Abstract
{
    public interface ICategoryService
    {
        ICollection<Category> FindAll();
        Category FindById(int id);
        Category FindByName([NotNull] string name);
        ServiceResult Add([NotNull] Category category);
        ServiceResult Update([NotNull] Category category);
        ServiceResult RemoveById(int id);
    }
}
