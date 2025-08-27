using ghibli_suggestion_api.Clients;
using ghibli_suggestion_api.Models;

namespace ghibli_suggestion_api.Services;

public class GhibliService : IGhibliService
{
    private readonly IGhibliApiClient _client;

    public GhibliService(IGhibliApiClient client)
    {
        _client = client;
    }
    
    public Task<IEnumerable<FilmDto>?> GetFilmsAsync()
    {
        throw new NotImplementedException();
    }

    public Task<FilmDto?> GetFilmAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<FilmDto>?> SuggestFilmAsync(FilmDto filmDto)
    {
        throw new NotImplementedException();
    }
}