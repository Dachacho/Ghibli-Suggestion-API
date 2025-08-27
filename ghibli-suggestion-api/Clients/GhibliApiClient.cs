using System.Text.Json;
using ghibli_suggestion_api.Models;

namespace ghibli_suggestion_api.Clients;

public class GhibliApiClient : IGhibliApiClient
{
    private readonly HttpClient _client;

    public GhibliApiClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<IEnumerable<GhibliFilm>?> GetFilmsAsync()
    {
        var response = await _client.GetAsync($"/films");
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<IEnumerable<GhibliFilm>>(content,  
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }

    public async Task<GhibliFilm?> GetFilmAsync(int id)
    {
        var response = await _client.GetAsync($"/films/{id}");
        response.EnsureSuccessStatusCode();
        
        var content = await response.Content.ReadAsStringAsync();
        return JsonSerializer.Deserialize<GhibliFilm>(content, 
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
    }
}