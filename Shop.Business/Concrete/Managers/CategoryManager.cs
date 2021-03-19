using Core.Aspects.Postsharp.ExceptionHandlingAspects;
using Core.Aspects.Postsharp.ValidationAspects;
using Core.Utilities.ServiceResult;
using Shop.Business.Abstract;
using Shop.Business.ValidationRules.FluentValidation;
using Shop.DataAccess.Abstract;
using Shop.Entities.Concrete;
using System.Collections.Generic;

namespace Shop.Business.Concrete.Managers
{
    [ExceptionHandleAspect]
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public ICollection<Category> FindAll() =>
            _categoryRepository.FindAll();

        public Category FindById(int id) =>
            _categoryRepository.Find(x => x.Id == id);

        public Category FindByName(string name) =>
            string.IsNullOrWhiteSpace(name) ? null : _categoryRepository.Find(x => string.Equals(x.Name, name));

        [FluentValidationAspect(typeof(CategoryValidator))]
        public ServiceResult Add(Category category)
        {
            category.Id = default;
            _categoryRepository.Add(category);
            return ServiceResult.Success();
        }

        [FluentValidationAspect(typeof(CategoryValidator))]
        public ServiceResult Update(Category category)
        {
            _categoryRepository.Update(category);
            return ServiceResult.Success();
        }

        public ServiceResult RemoveById(int id)
        {
            var categoryCheckChild = _categoryRepository.CheckChildExist(x => x.Id == id);

            if (categoryCheckChild == null)
                return ServiceResult.Fail(ServiceError.EntityNotFound(nameof(Category), (nameof(Category.Id), id)));

            if (categoryCheckChild.IsProductExist)
                return ServiceResult.Fail(ServiceError.ForeignKeyUsing(nameof(Category), nameof(Category.Products)));

            _categoryRepository.Remove(new Category { Id = id });
            return ServiceResult.Success();
        }
    }
}
