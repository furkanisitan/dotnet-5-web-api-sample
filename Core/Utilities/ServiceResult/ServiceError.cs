namespace Core.Utilities.ServiceResult
{
    public class ServiceError
    {
        public string Code { get; set; }
        public string Description { get; set; }

        public ServiceError() { }

        public ServiceError(string code, string description)
        {
            Code = code;
            Description = description;
        }


        #region ErrorCodes
        public const string ValidationError = "ValidationError";
        public const string DuplicateError = "DuplicateError";
        public const string ConflictError = "ConflictError";
        public const string NotFoundError = "NotFoundError";
        public const string AuthenticationError = "AuthenticationError";
        public const string UnexpectedError = "UnexpectedError";
        #endregion

        public static ServiceError EntityNotFound(string entity, params (string, object)[] parameters)
        {
            var description = string.IsNullOrWhiteSpace(entity) ? "Not found" : $"{entity} not found";

            if (parameters.Length > 0)
            {
                description += " for parameters";
                foreach (var (item1, item2) in parameters)
                    description += $" {{{item1}={item2}}},";
                description = description.TrimEnd(',');
            }
            description += ".";
            return new ServiceError(NotFoundError, description);
        }


        public static ServiceError ForeignKeyNotFound(string foreignKey) =>
            new(ConflictError, $"FOREIGN KEY constraint: '{foreignKey}' could not be found.");

        public static ServiceError ForeignKeyUsing(string entity, string foreignKeyTable) =>
            new(ConflictError, $"FOREIGN KEY constraint: The primary key of this {entity} is using as a foreign key in '{foreignKeyTable}' table.");
    }
}
