using MovieManager.Entities;

namespace MovieManager.Models;

public class ManageMovieViewModel
{
    public Movie Movie { get; set; }
    public List<Genre> AllGenres { get; set; }
    public Genre SelectedGenre { get; set; }
}