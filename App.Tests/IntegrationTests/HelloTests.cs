using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

public class BasicTests
    : IClassFixture<WebApplicationFactory<App.Startup>>
{
    private readonly WebApplicationFactory<App.Startup> _factory;

    public BasicTests(WebApplicationFactory<App.Startup> factory)
    {
        _factory = factory;
    }

    [Theory]
    [InlineData("/Hello?Name=Someone")]
    public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
    {
        // Arrange
        var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(url);

        // Assert
        response.EnsureSuccessStatusCode(); // Status Code 200-299
        Assert.Equal("text/html; charset=utf-8",
            response.Content.Headers.ContentType.ToString());
    }
}