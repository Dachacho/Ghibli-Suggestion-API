using ghibli_suggestion_api.Models;

namespace ghibli_suggestion_api.Mapper;

public static class FilmMapper
{
    public static FilmDto ToDto(GhibliFilm film)
    {
        ArgumentNullException.ThrowIfNull(film);
        
        var score = int.TryParse(film.RtScore?.Trim(), out var s) ? s : 0;
        var runningTime = int.TryParse(film.RunningTime?.Trim(), out var rt) ? rt : 0;

        var lengthCategory = runningTime switch
        {
            < 90 => "short",
            <= 120 => "medium",
            _ => "long"
        };

        var mood = score switch
        {
            >= 95 => "exciting",
            >= 70 => "cheerful",
            >= 50 => "calm",
            _ => "thoughtful"
        };

        var pairing = mood switch
        {
            "thoughtful" => "alone",
            "cheerful" => "friends",
            "exciting" => "family",
            "calm" => "alone",
            _ => "anyone"
        };

        return new FilmDto
        {
            Id = film.Id,
            Title = film.Title,
            Mood = mood,
            LengthCategory = lengthCategory,
            Pairing = pairing,
        };
    }
}