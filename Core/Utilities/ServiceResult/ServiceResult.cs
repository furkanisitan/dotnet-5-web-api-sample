using System.Collections.Generic;

namespace Core.Utilities.ServiceResult
{
    public class ServiceResult
    {
        private readonly List<ServiceError> _errors = new();

        public bool IsSuccess { get; protected set; }
        public IEnumerable<ServiceError> Errors => _errors;

        public static ServiceResult Success() => new() { IsSuccess = true };

        public static ServiceResult Fail(params ServiceError[] errors)
        {
            var result = new ServiceResult { IsSuccess = false };
            if (errors != null) result._errors.AddRange(errors);
            return result;
        }

        public static ServiceResult Fail(string errorCode, string errorDescription)
        {
            var result = new ServiceResult { IsSuccess = false };
            if (!string.IsNullOrWhiteSpace(errorCode))
                result._errors.Add(new ServiceError(errorCode, errorDescription));
            return result;
        }
    }
}
