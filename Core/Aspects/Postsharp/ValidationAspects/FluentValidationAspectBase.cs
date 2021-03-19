using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities.Extensions;
using FluentValidation;
using PostSharp.Aspects;
using PostSharp.Extensibility;
using PostSharp.Serialization;
using System;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;

namespace Core.Aspects.Postsharp.ValidationAspects
{
    [PSerializable]
    public abstract class FluentValidationAspectBase : OnMethodBoundaryAspect
    {
        protected IValidator _validator;
        protected Type _validatorType;
        protected string[] _ruleSets;

        protected FluentValidationAspectBase(Type validatorType, params string[] ruleSets)
        {
            _validatorType = validatorType;
            _ruleSets = ruleSets;
        }

        public override bool CompileTimeValidate(MethodBase method)
        {
            if (!_validatorType.IsAssignableToGenericType(typeof(AbstractValidator<>)))
                throw new InvalidAnnotationException($"The validatorType is not declared in a type derived from {typeof(AbstractValidator<>).FullName}.");

            return base.CompileTimeValidate(method);
        }

        public override void RuntimeInitialize(MethodBase method)
        {
            _validator = (IValidator)Activator.CreateInstance(_validatorType);
            base.RuntimeInitialize(method);
        }

        public override void OnEntry(MethodExecutionArgs args)
        {
            var entityType = _validatorType.BaseType?.GetGenericArguments()[0];
            var genericValidateMethod = typeof(ValidatorTool).GetMethod(nameof(ValidatorTool.Validate))?.MakeGenericMethod(entityType!);
            var entities = args.Arguments.Where(x => x.GetType() == entityType);

            try
            {
                foreach (var entity in entities)
                    genericValidateMethod?.Invoke(null, new[] { _validator, entity, _ruleSets });
            }
            catch (TargetInvocationException e)
            {
                ExceptionDispatchInfo.Capture(e.InnerException ?? e).Throw();
            }
        }
    }
}
