using System.Net.Http;
using System.Threading.Tasks;
using _cInsights;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

public class WebCheck
{
    private readonly TestServer _server;
    private readonly HttpClient _client;

    public WebCheck()
    {
        // Arrange
        _server = new TestServer(new WebHostBuilder()
            .UseStartup<Startup>());
        _client = _server.CreateClient();
    }

    private async Task<string> GetResponseHealthCheckString(
       string querystring = "")
    {
        var request = "/v1/healthcheck";
      
        var response = await _client.GetAsync(request);
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadAsStringAsync();
    }

    [Fact]
    public async Task ReturnHealthCheckString()
    {
        // Act
        var responseString = await GetResponseHealthCheckString();

        // Assert
        Assert.Equal("\"ALIVE\"", responseString);
    }

}