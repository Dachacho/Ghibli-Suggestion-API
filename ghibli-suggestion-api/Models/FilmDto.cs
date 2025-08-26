namespace ghibli_suggestion_api.Models;

public class FilmDto
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string Mood { get; set; } = null!;
    public string LengthCategory { get; set; } = null!;
    public string Pairing { get; set; } = null!;
}