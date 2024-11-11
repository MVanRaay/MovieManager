using MovieManager.Entities;

namespace MovieManager.Services;

public interface IMovieManagerService
{
    public List<Movie> GetAllMovies();
    public Movie GetMovieById(int movieId);
    public void AddMovie(Movie movie);
    public void UpdateMovie(Movie movie);
    public void DeleteMovie(Movie movie);
    public List<Genre> GetAllGenres();
    public Genre GetGenreById(int genreId);
    public void AddGenre(Genre genre);
    public void UpdateGenre(Genre genre);
    public void DeleteGenre(Genre genre);
    public List<Actor> GetAllActors();
    public Actor GetActorById(int actorId);
    public void AddActor(Actor actor);
    public void UpdateActor(Actor actor);
    public void DeleteActor(Actor actor);
}