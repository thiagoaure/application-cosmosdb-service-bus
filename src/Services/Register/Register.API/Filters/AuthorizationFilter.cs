using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos.Linq;
using Register.API.Helpers;

namespace Register.API.Filters;

public class AuthorizationFilter : IAuthorizationFilter
{
    private readonly string key = ConfigurationConnectionStrings.ConfigConnection().
            GetValue<string>("AccountKey");
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        string contentType = context.HttpContext.Request.Headers["Content-Type"];
        Console.WriteLine(contentType);
        if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
        {
            context.Result = new UnauthorizedResult();
            return;
        }
        string? token = context.HttpContext.Request.Headers["Authorization"];

        bool isTokenValid = ValidateToken(token);

        if (!isTokenValid)
        {
            context.Result = new UnauthorizedResult();
            return;
        }
    }

    private bool ValidateToken(string token)
    {
        if (token.IsNull() || token != key)
        {
            return true;
        }
        return false;
    }
}
