using ghibli_suggestion_api.Models;
using ghibli_suggestion_api.Services;
using Microsoft.AspNetCore.Mvc;

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

    [HttpGet]
    public async Task<ActionResult<IEnumerable<FilmDto>>> GetFilmsAsync()
    {
        var films  = await _ghibliService.GetFilmsAsync();
        return Ok(films);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<FilmDto?>> GetFilmAsync(string id)
    {
        var film = await _ghibliService.GetFilmAsync(id);
        return Ok(film);
    }

    [HttpGet("suggest")]
    public async Task<ActionResult<IEnumerable<FilmDto>>> SuggestFilmAsync(
        [FromQuery] string mood, [FromQuery] string length, [FromQuery] string pairing)
    {
        var suggestion = await _ghibliService.SuggestFilmAsync(mood, length, pairing);
        return Ok(suggestion);
    }
}