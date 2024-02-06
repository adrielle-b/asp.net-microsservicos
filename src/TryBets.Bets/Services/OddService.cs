using System.Net.Http;
using System.Text.Json;
namespace TryBets.Bets.Services;

public class OddService : IOddService
{
    private readonly HttpClient _client;
    public OddService(HttpClient client)
    {
        _client = client;
    }

    public async Task<object> UpdateOdd(int MatchId, int TeamId, decimal BetValue)
    {
        var request = new HttpRequestMessage(HttpMethod.Patch, $"http://localhost:5000/Odd/{MatchId}/{TeamId}/{BetValue}");
        request.Headers.Add("Accept", "application/json");
        request.Headers.Add("User-Agent", "aspnet-user-agent");

        var response = await _client.SendAsync(request);
        var responseOdd = await response.Content.ReadFromJsonAsync<object>();
        return responseOdd!;
    }
}