using System;

namespace Core.Utilities.CustomExceptions
{
    [Serializable]
    public class InvalidGenericTypeException : Exception
    {
        public InvalidGenericTypeException(Type invalidType) : base($"{invalidType.FullName} is not the expected generic type.") { }

        public InvalidGenericTypeException(string message) : base(message) { }
    }
}
