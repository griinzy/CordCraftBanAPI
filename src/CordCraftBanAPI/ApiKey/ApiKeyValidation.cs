namespace CordCraftBanAPI.ApiKey
{
    public class ApiKeyValidation : IApiKeyValidation
    {
        public bool IsValidApiKey(string userApiKey)
        {
            if (string.IsNullOrWhiteSpace(userApiKey)) return false;

            using (StreamReader reader = new StreamReader("apikeys.txt"))
            {
                string line;
                while((line = reader.ReadLine()) != null)
                {
                    if (line.Equals(userApiKey)) return true;
                }
            }
            return false;
        }
    }
}
