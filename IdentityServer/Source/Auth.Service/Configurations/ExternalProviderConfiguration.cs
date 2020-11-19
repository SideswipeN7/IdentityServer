namespace Auth.Service.Configurations
{
    public record ExternalProviderConfiguration(string Name, bool IsActive, string ClientId, string ClientSecret);
}