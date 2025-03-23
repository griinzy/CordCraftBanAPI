using Microsoft.AspNetCore.Mvc;

namespace CordCraftBanAPI.ApiKey
{
    public class ApiKeyAttribute : ServiceFilterAttribute
    {
        public ApiKeyAttribute() : base(typeof(ApiKeyAuthFilter))
        {

        }
    }
}
