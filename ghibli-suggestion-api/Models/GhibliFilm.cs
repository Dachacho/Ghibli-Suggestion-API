namespace ghibli_suggestion_api.Models;

public class GhibliFilm
{
    public string Id { get; set; } = null!;
    public string Title { get; set; } = null!;
    public string OriginalTitle { get; set; } = null!;
    public string OriginalTitleRomanised { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string Director { get; set; } = null!;
    public string Producer { get; set; } = null!;
    public string ReleaseDate { get; set; } = null!;
    public string RunningTime { get; set; } = null!;
    public string RtScore { get; set; } = null!;
    public List<string> People { get; set; } = new();
    public List<string> Species { get; set; } = new();
    public List<string> Locations { get; set; } = new();
    public List<string> Vehicles { get; set; } = new();
    public string Url { get; set; } = null!;
}