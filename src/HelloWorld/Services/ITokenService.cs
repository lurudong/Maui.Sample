namespace HelloWorld.Services;

public interface ITokenService
{
    Task<string> GetToken();
}

public sealed class TokenService : ITokenService
{


    public async Task<string> GetToken()
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync("https://v2.jinrishici.com/token");
        var josn = await response.Content.ReadAsStringAsync();
        return josn;
    }
}
