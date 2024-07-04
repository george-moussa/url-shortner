using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using UrlShortner.Helper;

namespace UrlShortner.Security;

public class ClaimsTransformation : IClaimsTransformation
{
    // SM: This gets called with every single API endpoint that has [Authorize] in it or its controller
    // Only AllowAnonymous will bypass this step
    public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
    {
        var identity = principal.Identity as ClaimsIdentity;

        var email = principal.FindFirstValue("emails");

        // SM: If we cannot get the email, we will throw an unauthorized exception
        if (string.IsNullOrWhiteSpace(email))
        {
            throw new UnauthorizedAccessException("Email not provided");
        }

        var user = DataMock.GetUserByEmail(email)
                // SM: This line below throws an error if there is user is not in our database
                ?? throw new UnauthorizedAccessException("Invalid user!");  

        // SM: This pulls all the roles of the user from the database, then add it to the list of claims
        // Because C# middleware already has the matrix of roles and permissions, C# will handle authorization
        // automatically
        var newClaims = user.Roles.Select(role => new Claim(ClaimTypes.Role, role));

        identity!.AddClaims(newClaims);

        return Task.FromResult(principal);
    }
}
