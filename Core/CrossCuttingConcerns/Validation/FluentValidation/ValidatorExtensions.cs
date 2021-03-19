using Core.CrossCuttingConcerns.Validation.FluentValidation.HelperValidators;
using Core.Entities;
using FluentValidation;
using System;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidatorExtensions
    {
        /// <summary>
        /// Checks the uniqueness of the property of the current item.
        /// </summary>
        /// <typeparam name="TEntity">The type of the current item.</typeparam>
        /// <typeparam name="TProperty">The type of the current property.</typeparam>
        /// <typeparam name="TKey">The type used for the primary key.</typeparam>
        /// <param name="ruleBuilder"></param>
        /// <param name="getOriginalItem">A function that returns the original instance of the current item.</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<TEntity, TProperty> IsUnique<TEntity, TProperty, TKey>(this IRuleBuilder<TEntity, TProperty> ruleBuilder, Func<TEntity, TEntity> getOriginalItem)
            where TEntity : class, IEntity<TKey>, new()
        where TKey : IEquatable<TKey>
        {
            return ruleBuilder.SetValidator(new UniqueValidator<TEntity, TKey>(getOriginalItem));
        }
    }
}
