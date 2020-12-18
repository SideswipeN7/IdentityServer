namespace Auth.Service.Configurations
{
    public class ExternalProviderConfiguration {
        public string Name { get; init; }
        public bool IsActive { get; init; }
        public string ClientId { get; init; }
        public string ClientSecret { get; init; }
    }
}