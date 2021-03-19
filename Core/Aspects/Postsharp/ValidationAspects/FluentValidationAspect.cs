using Core.CrossCuttingConcerns.Validation.FluentValidation;
using FluentValidation;
using PostSharp.Serialization;
using System;

namespace Core.Aspects.Postsharp.ValidationAspects
{
    /// <summary>
    /// Aspect that, when applied to a method, runs the <see cref="ValidatorTool.Validate{T}"/> method for the related method parameters.
    /// </summary>
    [PSerializable]
    public sealed class FluentValidationAspect : FluentValidationAspectBase
    {
        /// <param name="validatorType">The type of validation class.</param>
        /// <param name="ruleSets">The names of the ruleSets to validation.</param>
        /// <exception cref="ValidationException">Throw when validation is failed.</exception>
        public FluentValidationAspect(Type validatorType, params string[] ruleSets) : base(validatorType, ruleSets) { }
    }
}
