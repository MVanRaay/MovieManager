using Microsoft.EntityFrameworkCore;
using MovieManager.Entities;

namespace MovieManager.Services;

public class MovieManagerService : IMovieManagerService
{
    private MovieManagerDbContext _context;

    public MovieManagerService(MovieManagerDbContext context)
    {
        _context = context;
    }

    public List<Movie> GetAllMovies()
    {
        return _context.Movies.Include(m => m.Genres.OrderBy(g => g.Name)).OrderBy(m => m.Title).ToList();
    }

    public Movie GetMovieById(int movieId)
    {
        return _context.Movies.Include(m => m.Genres.OrderBy(g => g.Name)).FirstOrDefault(m => m.MovieId == movieId);
    }

    public void AddMovie(Movie movie)
    {
        _context.Movies.Add(movie);
        _context.SaveChanges();
    }

    public void UpdateMovie(Movie movie)
    {
        _context.Movies.Update(movie);
        _context.SaveChanges();
    }

    public void DeleteMovie(Movie movie)
    {
        _context.Movies.Remove(movie);
        _context.SaveChanges();
    }

    public List<Genre> GetAllGenres()
    {
        return _context.Genres.OrderBy(g => g.Name).ToList();
    }

    public Genre GetGenreById(int genreId)
    {
        return _context.Genres.FirstOrDefault(g => g.GenreId == genreId);
    }

    public void AddGenre(Genre genre)
    {
        _context.Genres.Add(genre);
        _context.SaveChanges();
    }

    public void UpdateGenre(Genre genre)
    {
        _context.Genres.Update(genre);
        _context.SaveChanges();
    }

    public void DeleteGenre(Genre genre)
    {
        _context.Genres.Remove(genre);
        _context.SaveChanges();
    }

    public List<Actor> GetAllActors()
    {
        return _context.Actors.OrderBy(a => a.LastName).ToList();
    }

    public Actor GetActorById(int actorId)
    {
        return _context.Actors.FirstOrDefault(a => a.ActorId == actorId);
    }

    public void AddActor(Actor actor)
    {
        _context.Actors.Add(actor);
        _context.SaveChanges();
    }

    public void UpdateActor(Actor actor)
    {
        _context.Actors.Update(actor);
        _context.SaveChanges();
    }

    public void DeleteActor(Actor actor)
    {
        _context.Actors.Remove(actor);
        _context.SaveChanges();
    }
}