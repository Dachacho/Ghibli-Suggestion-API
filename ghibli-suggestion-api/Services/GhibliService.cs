using ghibli_suggestion_api.Clients;
using ghibli_suggestion_api.Mapper;
using ghibli_suggestion_api.Models;
using Microsoft.Extensions.Caching.Memory;

namespace ghibli_suggestion_api.Services;

public class GhibliService : IGhibliService
{
    private readonly IGhibliApiClient _client;
    private readonly IMemoryCache _cache;
    
    public GhibliService(IGhibliApiClient client,  IMemoryCache cache)
    {
        _client = client;
        _cache = cache;
    }

    public async Task<IEnumerable<FilmDto>?> GetFilmsAsync()
    {
        return await _cache.GetOrCreateAsync("all_films", async entry =>
        {
            Console.WriteLine("getting movies from api");
            var films = await _client.GetFilmsAsync();
            return films?.Select(FilmMapper.ToDto);
        });
    }

    public async Task<FilmDto?> GetFilmAsync(string id)
    {
        var film = await _client.GetFilmAsync(id);
        return film != null ? FilmMapper.ToDto(film) : null;
    }

    public async Task<IEnumerable<FilmDto>?> SuggestFilmAsync(string? mood, string? length, string? pairing)
    {
        var films = await _client.GetFilmsAsync();
        var dtos = films?.Select(FilmMapper.ToDto);

        if (dtos != null)
        {
            var filtered = dtos
                .Where(f => string.IsNullOrEmpty(mood) || f.Mood == mood)
                .Where(f => string.IsNullOrEmpty(length) || f.LengthCategory == length)
                .Where(f => string.IsNullOrEmpty(pairing) || f.Pairing == pairing);
        
            var random =  new Random();
            return filtered.OrderBy(_ => random.Next()).Take(3);
        }

        return [];
    }
}