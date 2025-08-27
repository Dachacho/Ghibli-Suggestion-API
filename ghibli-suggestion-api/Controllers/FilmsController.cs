namespace ghibli_suggestion_api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FilmsController : ControllerBase
{
    private readonly IGhibliService _ghibliService;

    public FilmsController(IGhibliService ghibliService)
    {
        _ghibliService = ghibliService;
    }

    [HttpGet("GetFilms")]
    public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilmsAsync()
    {
        var films  = await _ghibliService.GetFilmsAsync();
        return Ok(films);
    }

    [HttpGet("GetFilms/{id}")]
    public async Task<ActionResult<FilmDto?>> GetFilmAsync(string id)
    {
        var film = await _ghibliService.GetFilmAsync(id);
        return Ok(film);
    }

    [HttpGet("SuggestFilms")]
    public async Task<ActionResult<IEnumerable<FilmDto>>> SuggestFilmAsync([FromQuery]FilmSuggestionQuery query)
    {
        var suggestion = await _ghibliService.SuggestFilmAsync(query);
        return Ok(suggestion);
    }
}