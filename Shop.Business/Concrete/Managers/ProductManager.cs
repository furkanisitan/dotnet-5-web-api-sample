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
    public class ProductManager : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductManager(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public ICollection<Product> FindAll() =>
            _productRepository.FindAll();

        public ICollection<Product> FindAllByCategoryId(int categoryId) =>
            _productRepository.FindAll(x => x.CategoryId == categoryId);

        public Product FindById(int id) =>
            _productRepository.Find(x => x.Id == id);

        public Product FindByName(string name) =>
             string.IsNullOrWhiteSpace(name) ? null : _productRepository.Find(x => string.Equals(x.Name, name));

        [FluentValidationAspect(typeof(ProductValidator))]
        public ServiceResult Add(Product product)
        {
            var isCategoryExist = _categoryRepository.Exists(x => x.Id == product.CategoryId);

            if (!isCategoryExist)
                return ServiceResult.Fail(ServiceError.ForeignKeyNotFound(nameof(Product.CategoryId)));

            product.Id = default;
            _productRepository.Add(product);
            return ServiceResult.Success();
        }

        [FluentValidationAspect(typeof(ProductValidator))]
        public ServiceResult Update(Product product)
        {
            var existsCategory = _categoryRepository.Exists(x => x.Id == product.CategoryId);

            if (!existsCategory)
                return ServiceResult.Fail(ServiceError.ForeignKeyNotFound(nameof(Product.CategoryId)));

            _productRepository.Update(product);
            return ServiceResult.Success();
        }

        public ServiceResult RemoveById(int id)
        {
            var existsProduct = _productRepository.Exists(x => x.Id == id);
            if (!existsProduct)
                return ServiceResult.Fail(ServiceError.EntityNotFound(nameof(Product), (nameof(Product.Id), id)));

            _productRepository.Remove(new Product { Id = id });
            return ServiceResult.Success();
        }
    }
}