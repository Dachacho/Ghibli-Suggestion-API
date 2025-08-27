using ghibli_suggestion_api.Models;

namespace ghibli_suggestion_api.Clients;

public interface IGhibliApiClient
{
    Task<IEnumerable<GhibliFilm>?> GetFilmsAsync();
    Task<GhibliFilm?> GetFilmAsync(string id);
}