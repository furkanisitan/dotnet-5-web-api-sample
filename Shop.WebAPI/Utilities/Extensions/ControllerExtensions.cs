using Core.Utilities.ServiceResult;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Shop.WebAPI.Utilities.Extensions
{
    public static class ControllerExtensions
    {
        #region ServiceResult

        public static IActionResult FailedFromServiceResult(this Controller controller, ServiceResult serviceResult)
        {
            if (serviceResult.IsSuccess) return controller.NoContent();

            var firstError = serviceResult.Errors?.FirstOrDefault();

            switch (firstError?.Code)
            {
                case ServiceError.NotFoundError:
                    return controller.NotFound(GetFailedResponse(serviceResult.Errors));
                case ServiceError.DuplicateError:
                case ServiceError.ConflictError:
                    return controller.Conflict(GetFailedResponse(serviceResult.Errors));
                case ServiceError.ValidationError:
                    return controller.BadRequest(GetFailedResponse(serviceResult.Errors));
                case ServiceError.AuthenticationError:
                    return controller.Unauthorized(GetFailedResponse(ServiceError.AuthenticationError, "Username or password is incorrect."));
                default:
                    return controller.BadRequest(GetFailedResponse(ServiceError.UnexpectedError, "An unexpected error has occurred."));
            }
        }

        public static IActionResult FailedNotFound(this Controller controller, string itemName, params (string, object)[] parameters)
        {
            var errors = new List<ServiceError> { ServiceError.EntityNotFound(itemName, parameters) };
            return controller.NotFound(GetFailedResponse(errors));
        }

        private static object GetFailedResponse(IEnumerable<ServiceError> errors) =>
            new { errors };

        private static object GetFailedResponse(string code, string description) =>
             new { errors = new ServiceError[] { new() { Code = code, Description = description } } };
        #endregion
    }
}
