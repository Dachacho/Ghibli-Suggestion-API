namespace ghibli_suggestion_api.Models;

public class GhibliFilm
{
    [JsonPropertyName("id")]
    public string Id { get; set; } = null!;

    [JsonPropertyName("title")]
    public string Title { get; set; } = null!;

    [JsonPropertyName("original_title")]
    public string OriginalTitle { get; set; } = null!;

    [JsonPropertyName("original_title_romanised")]
    public string OriginalTitleRomanised { get; set; } = null!;

    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;

    [JsonPropertyName("director")]
    public string Director { get; set; } = null!;

    [JsonPropertyName("producer")]
    public string Producer { get; set; } = null!;

    [JsonPropertyName("release_date")]
    public string ReleaseDate { get; set; } = null!;

    [JsonPropertyName("running_time")]
    public string RunningTime { get; set; } = null!;

    [JsonPropertyName("rt_score")]
    public string RtScore { get; set; } = null!;

    [JsonPropertyName("people")]
    public List<string> People { get; set; } = new();

    [JsonPropertyName("species")]
    public List<string> Species { get; set; } = new();

    [JsonPropertyName("locations")]
    public List<string> Locations { get; set; } = new();

    [JsonPropertyName("vehicles")]
    public List<string> Vehicles { get; set; } = new();

    [JsonPropertyName("url")]
    public string Url { get; set; } = null!;
}