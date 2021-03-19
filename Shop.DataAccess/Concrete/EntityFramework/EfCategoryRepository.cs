using Core.DataAccess.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Shop.DataAccess.Abstract;
using Shop.DataAccess.Concrete.EntityFramework.Configuration;
using Shop.Entities.Concrete;
using Shop.Entities.DTOs.Category;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Shop.DataAccess.Concrete.EntityFramework
{
    public class EfCategoryRepository : EfRepository<Category, ApplicationDbContext, int>, ICategoryRepository
    {
        public CategoryCheckChildExist CheckChildExist(Expression<Func<Category, bool>> predicate)
        {
            using var context = new ApplicationDbContext();
            return context.Categories.Where(predicate)
                .Include(x => x.Products)
                .Select(x => new CategoryCheckChildExist
                {
                    IsProductExist = x.Products.Any()
                }).FirstOrDefault();
        }
    }
}
