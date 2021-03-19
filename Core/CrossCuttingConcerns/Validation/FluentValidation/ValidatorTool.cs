using Core.Entities;
using FluentValidation;
using System.Linq;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidatorTool
    {
        /// <summary>
        /// Validates the <paramref name="entity"/>.
        /// </summary>
        /// <typeparam name="TEntity">The type of <paramref name="entity"/>.</typeparam>
        /// <param name="validator">The validator to validate the <paramref name="entity"/>.</param>
        /// <param name="entity">The entity to validate.</param>
        /// <param name="ruleSets">The names of the ruleSets to validation.</param>
        /// <exception cref="ValidationException">Throw when validation is failed.</exception>
        public static void Validate<TEntity>(IValidator<TEntity> validator, TEntity entity, params string[] ruleSets)
            where TEntity : class, IEntity, new()
        {
            var result = validator.Validate(entity, options => options.IncludeRuleSets(ruleSets));
            if (result.Errors.Any()) throw new ValidationException(result.Errors);
        }
    }
}
