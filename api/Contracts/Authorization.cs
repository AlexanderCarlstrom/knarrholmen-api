namespace api.Contracts
{
    public static class Authorization
    {
        public static readonly string DefaultPassword = "Alexander1%";
        public const string RefreshTokenCookieName = "X-Refresh-Token";
        public const string AccessTokenCookieName = "X-Access-Token";
    }
}