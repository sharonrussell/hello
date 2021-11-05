using System;
using System.Threading.Tasks;
using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Microsoft.Extensions.Configuration;

public static class AccessTokenHelper
{
    public static async Task<string> GetAccessToken(IConfigurationSection auth0Settings)
    {
        var auth0Client = new AuthenticationApiClient(new Uri(auth0Settings["Domain"]));

        var tokenRequest = new ClientCredentialsTokenRequest()
        {
            ClientId = auth0Settings["ClientId"],
            ClientSecret = Environment.GetEnvironmentVariable("MyAPP_Auth0__ClientSecret"),
            Audience = auth0Settings["Audience"]
        };
        var tokenResponse = await auth0Client.GetTokenAsync(tokenRequest);

        return tokenResponse.AccessToken;
    }
}