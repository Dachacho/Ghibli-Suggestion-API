using ghibli_suggestion_api.Models;

namespace ghibli_suggestion_api.Services;

public interface IGhibliService
{
    Task<IEnumerable<FilmDto>?> GetFilmsAsync();
    Task<FilmDto?> GetFilmAsync(int id);
    Task<IEnumerable<FilmDto>?> SuggestFilmAsync(FilmDto filmDto);
}   