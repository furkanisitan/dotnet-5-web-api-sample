using Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using Shop.Business.Abstract;
using Shop.Business.DependencyResolvers;
using Shop.Entities.Concrete;

namespace Shop.Business.ValidationRules.FluentValidation
{
    public class ProductValidator : AbstractValidator<Product>
    {
        private static readonly IProductService ProductService = InstanceFactory.GetInstance<IProductService>();

        public ProductValidator()
        {

            RuleFor(x => x.Name).IsUnique<Product, string, int>(x => ProductService.FindByName(x.Name));
            RuleFor(x => x.Name).NotEmpty().MaximumLength(100);
            RuleFor(x => x.CategoryId).NotEmpty().GreaterThan(0);
            RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(x => x.UnitsInStock).GreaterThanOrEqualTo((short)0);
        }

    }
}
