using ghibli_suggestion_api.Models;

namespace ghibli_suggestion_api.Mapper;

public static class FilmMapper
{
    public static FilmDto ToDto(GhibliFilm film)
    {
        ArgumentNullException.ThrowIfNull(film);
        
        int score = int.TryParse(film.RtScore?.Trim(), out var s) ? s : 0;
        int runningTime = int.TryParse(film.RunningTime?.Trim(), out var rt) ? rt : 0;

        Console.WriteLine($"Film: {film.Title}, RtScore (raw): '{film.RtScore}', parsed: {score}, RunningTime (raw): '{film.RunningTime}', parsed: {runningTime}");
        
        var lengthCategory = runningTime switch
        {
            < 70 => "short",
            <= 100 => "medium",
            _ => "long"
        };

        string mood;
        if (score >= 90) mood = "exciting";
        else if (score >= 70) mood = "cheerful";
        else if (score >= 50) mood = "calm";
        else mood = "thoughtful";

        string pairing = mood switch
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