namespace ghibli_suggestion_api.Services;

public interface IGhibliService
{
    Task<IEnumerable<FilmDto>?> GetFilmsAsync();
    Task<FilmDto?> GetFilmAsync(string id);
    Task<IEnumerable<FilmDto>?> SuggestFilmAsync(string? mood, string? length, string? pairing);
}   