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

    public async Task<IEnumerable<FilmDto>?> SuggestFilmAsync(FilmSuggestionQuery query)
    {
        var films = await _client.GetFilmsAsync();
        var dtos = films?.Select(FilmMapper.ToDto);

        if (dtos != null)
        {
            var filtered = dtos
                .Where(f => string.IsNullOrEmpty(query.Mood) || f.Mood == query.Mood)
                .Where(f => string.IsNullOrEmpty(query.Length) || f.LengthCategory == query.Length)
                .Where(f => string.IsNullOrEmpty(query.Pairing) || f.Pairing == query.Pairing);
        
            var random =  new Random();
            return filtered.OrderBy(_ => random.Next()).Take(3);
        }

        return [];
    }
}