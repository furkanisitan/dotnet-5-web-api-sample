using Core.DataAccess;
using Shop.Entities.Concrete;
using Shop.Entities.DTOs.Category;
using System;
using System.Linq.Expressions;

namespace Shop.DataAccess.Abstract
{
    public interface ICategoryRepository : IRepository<Category, int>
    {
        CategoryCheckChildExist CheckChildExist(Expression<Func<Category, bool>> predicate);
    }
}
