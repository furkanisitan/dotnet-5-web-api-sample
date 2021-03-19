using Core.Entities;
using Core.Utilities.CustomExceptions;
using Core.Utilities.ServiceResult;
using FluentValidation.Validators;
using System;

namespace Core.CrossCuttingConcerns.Validation.FluentValidation.HelperValidators
{
    /// <summary>
    /// The class that checks the uniqueness of the property of the current item.
    /// </summary>
    /// <typeparam name="TEntity">The type of the current item.</typeparam>
    /// <typeparam name="TKey">The type used for the primary key.</typeparam>
    public class UniqueValidator<TEntity, TKey> : PropertyValidator
        where TEntity : class, IEntity<TKey>, new()
    where TKey : IEquatable<TKey>
    {
        private readonly Func<TEntity, TEntity> _getOriginalItem;

        /// <param name="getOriginalItem">A function that returns the original instance of the current item.</param>
        public UniqueValidator(Func<TEntity, TEntity> getOriginalItem)
        {
            ErrorCode = ServiceError.DuplicateError;
            _getOriginalItem = getOriginalItem;
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            if (!(context.InstanceToValidate is TEntity editedItem))
                throw new InvalidGenericTypeException(typeof(TEntity));

            var originalItem = _getOriginalItem(editedItem);
            return originalItem == null || originalItem.Id.Equals(editedItem.Id);
        }

        protected override string GetDefaultMessageTemplate() =>
            "{PropertyName} must be unique. RejectedValue: '{PropertyValue}'";
    }
}
