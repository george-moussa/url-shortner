using System.Net.Http.Headers;
using Azure.Core;
using Azure.Identity;

var scopes = new[] {$"api://.../access_as_user"};
var credential = new DefaultAzureCredential(includeInteractiveCredentials: true);
var requestContext = new TokenRequestContext();
var token = credential.GetToken(requestContext);

var httpClient = new HttpClient();
httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);

// Call the web API.
HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5209/weatherforecast");