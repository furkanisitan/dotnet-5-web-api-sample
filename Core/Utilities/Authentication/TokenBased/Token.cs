using System;

namespace Core.Utilities.Authentication.TokenBased
{
    public class Token
    {
        public string AccessToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
