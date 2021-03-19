using Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using Shop.Business.Abstract;
using Shop.Business.DependencyResolvers;
using Shop.Entities.Concrete;

namespace Shop.Business.ValidationRules.FluentValidation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        private static readonly ICategoryService CategoryService = InstanceFactory.GetInstance<ICategoryService>();

        public CategoryValidator()
        {
            RuleFor(x => x.Name).Cascade(CascadeMode.Stop).NotEmpty().MaximumLength(50)
                .IsUnique<Category, string, int>(x => CategoryService.FindByName(x.Name));
        }
    }
}
