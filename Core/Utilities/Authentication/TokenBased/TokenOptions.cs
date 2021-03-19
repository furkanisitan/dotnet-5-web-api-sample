namespace Core.Utilities.Authentication.TokenBased
{
    public class TokenOptions
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public string SecurityKey { get; set; }

        // minute
        public int Expiration { get; set; }
    }
}
