namespace HomeLab.Domain.Settings
{
    public class IdentitySettings
    {
        public string Authority { get; set; }
        public string PolicyClaim { get; set; }
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string[] Scopes { get; set; }
    }
}
