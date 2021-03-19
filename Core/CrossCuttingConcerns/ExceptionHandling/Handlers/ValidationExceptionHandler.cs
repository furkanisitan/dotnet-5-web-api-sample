using Core.Utilities.ServiceResult;
using FluentValidation;
using PostSharp.Aspects;
using System.Linq;

namespace Core.CrossCuttingConcerns.ExceptionHandling.Handlers
{
    /// <summary>
    /// The class that handled <see cref="ValidationException"/> exception.
    /// </summary>
    sealed class ValidationExceptionHandler : IExceptionHandler
    {
        /// <summary>
        /// Assigns a <see cref="ServiceResult"/> object to the args.ReturnValue if there is a <see cref="ValidationException"/> exception.
        /// </summary>
        /// <param name="args"></param>
        public void Execute(MethodExecutionArgs args)
        {
            if (args.Exception is not ValidationException exception) return;
            args.FlowBehavior = FlowBehavior.Return;
            args.ReturnValue = ServiceResult.Fail(exception.Errors.Select(exceptionError => new ServiceError { Code = GetErrorCode(exceptionError.ErrorCode), Description = exceptionError.ErrorMessage }).ToArray());
        }

        private string GetErrorCode(string errorCode)
        {
            switch (errorCode)
            {
                case ServiceError.DuplicateError:
                    return errorCode;
                default:
                    return ServiceError.ValidationError;
            }
        }
    }
}
