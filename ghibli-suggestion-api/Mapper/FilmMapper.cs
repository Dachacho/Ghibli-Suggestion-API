using ghibli_suggestion_api.Models;

namespace ghibli_suggestion_api.Mapper;

public static class FilmMapper
{
    public static FilmDto ToDto(GhibliFilm film)
    {
        ArgumentNullException.ThrowIfNull(film);

        var score = int.Parse(film.RtScore);
        var runningTime = int.Parse(film.RunningTime);
        
        var lengthCategory = runningTime < 90 ? "short" :
            runningTime <= 120 ? "medium" : "long";

        string mood;
        if (runningTime > 120 && score < 80)
            mood = "thoughtful";
        else if (score > 90 && runningTime <= 90)
            mood = "lighthearted";
        else
            mood = "adventurous";

        var pairing = mood == "thoughtful" ? "alone" :
            mood == "lighthearted" ? "friends" :
            "family";

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