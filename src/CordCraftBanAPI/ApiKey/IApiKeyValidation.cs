namespace CordCraftBanAPI.ApiKey
{
    public interface IApiKeyValidation
    {
        bool IsValidApiKey(string userApiKey);
    }
}
