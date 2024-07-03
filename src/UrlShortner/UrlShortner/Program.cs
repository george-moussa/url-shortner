using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using UrlShortner.Helper;
using UrlShortner.Security;

namespace UrlShortner;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();

        // SM: This is the authentication part where C# handles what comes
        // from the API header "Authorization"
        builder.Services.AddAuthentication(options =>
        {
            // SM: This defaults that the upcoming request is Bearer {JWT}
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        // SM: This adds the JWT bearer setup for OAuth 2.0. Using the values in the
        // app settings, it validates that the incoming bearer token is valid by sending
        // it back to the OAuth IdP
        .AddJwtBearer(options =>
        {
            options.Authority = builder.Configuration["AzureAdB2C:Authority"];
            options.RequireHttpsMetadata = false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = builder.Configuration["AzureAdB2C:Issuer"],
                ValidAudience = builder.Configuration["AzureAdB2C:Audience"]
            };
        })
        // SM: This adds the Basic authentication setup. C# expects "Basic username:password (in Base64)"
        // However, it doesn't handle the authentication. It sends it to "BasicAuthenticationHandler" which
        // determined if the username and password exist in the database
        .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

        // SM: This is the setup of the RBAC Authorization as it pulls the information from
        // the mock database, and establishes the permission to role relationship
        builder.Services.AddAuthorization(options =>
        {
            // SM: The line below gets the List of RolesPermissionsMatrix
            var permissionsByRoles = DataMock.RolesPermissionsMatrix
                // SM: The line below groups them as such
                // "AddCustomer": ["Priest"],
                // "ViewCustomerDetails": ["Priest", "Space Cowboy"],
                // "ViewReports": ["Priest", "Grand Wizard", "Chief Happiness Officer"], ...
                .GroupBy(rolePermission => rolePermission.Permission)
                // SM: A dictionary expects a key and a value. Our group.Key will be the permission
                // which somes from rolePermission.Permission
                // The value will be an array of all the roles link to that permission
                // by using the Linq Select statement
                .ToDictionary(
                    group => group.Key,
                    group => group.Select(_group => _group.Role).ToArray());

            // SM: Once we established the mapping, we will loop each permission (called Policy in C#)
            // and add it to the list of policies in C#'s middleware, and linking the roles
            foreach (var keyValuePair in permissionsByRoles)
            {
                options.AddPolicy(keyValuePair.Key, policy =>
                    // SM: keyValuePaid.Value is the array of roles that we picked up from
                    // the Select statement above
                    policy.RequireRole(keyValuePair.Value));
            }
        });

        // SM: When somebody is authenticated, we have to determine what are their roles
        // This is why we add "ClaimsTransformation". We use AddTransient as want to call this
        // for "each single API request" (Zero Trust)
        builder.Services.AddTransient<IClaimsTransformation, ClaimsTransformation>();

        var app = builder.Build();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
