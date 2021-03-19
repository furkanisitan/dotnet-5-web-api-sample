using System.Collections.Generic;
using System.Security.Claims;

namespace Core.Utilities.Authentication.TokenBased
{
    public abstract class TokenHelper
    {
        public abstract Token GetAccessToken(IEnumerable<Claim> claims);

    }
}
