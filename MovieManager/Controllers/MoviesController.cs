using Microsoft.AspNetCore.Mvc;
using MovieManager.Entities;
using MovieManager.Models;
using MovieManager.Services;

namespace MovieManager.Controllers;

public class MoviesController : Controller
{
    private readonly IMovieManagerService _service;

    public MoviesController(IMovieManagerService service)
    {
        _service = service;
    }

    // GET
    [HttpGet("/movies/all")]
    public IActionResult AllMovies()
    {
        var moviesList = _service.GetAllMovies();

        if (moviesList.Count < 1) return NotFound();

        var viewModel = new MoviesViewModel
        {
            Movies = moviesList
        };

        return View("All", viewModel);
    }

    // GET
    [HttpGet("/movie/add")]
    public IActionResult AddMovie()
    {
        var viewModel = new MovieViewModel
        {
            Movie = new Movie()
        };

        ViewBag.GenresList = _service.GetAllGenres();

        return View("Add", viewModel);
    }

    // POST
    [HttpPost("/movie/add")]
    public IActionResult AddMovie(MovieViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.GenresList = _service.GetAllGenres();
            return View("Add", viewModel);
        }

        _service.AddMovie(viewModel.Movie);

        TempData["Message"] = $"Movie {viewModel.Movie.Title} added successfully.";
        TempData["ColorName"] = "success";

        return RedirectToAction("AllMovies");
    }

    // GET
    [HttpGet("/movie/{movieId}/edit")]
    public IActionResult EditMovie(int movieId)
    {
        var viewModel = new MovieViewModel
        {
            Movie = _service.GetMovieById(movieId),
        };

        ViewBag.GenresList = _service.GetAllGenres();
        ViewBag.EditPage = "active";

        return View("Edit", viewModel);
    }

    // POST
    [HttpPost("/movie/{movieId}/edit")]
    public IActionResult EditMovie(MovieViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.EditPage = "active";
            return View("Edit", viewModel);
        }

        _service.UpdateMovie(viewModel.Movie);

        TempData["Message"] = $"Movie {viewModel.Movie.Title} updated successfully.";
        TempData["ColorName"] = "info";

        return RedirectToAction("AllMovies");
    }

    // GET
    [HttpGet("/movie/{movieId}/delete")]
    public IActionResult DeleteMovie(int movieId)
    {
        var viewModel = new MovieViewModel
        {
            Movie = _service.GetMovieById(movieId)
        };

        ViewBag.DeletePage = "active";

        return View("Delete", viewModel);
    }

    // POST
    [HttpPost("/movie/{movieId}/delete")]
    public IActionResult DeleteMovie(MovieViewModel viewModel)
    {
        var activeMovie = _service.GetMovieById(viewModel.Movie.MovieId);
        
        TempData["Message"] = $"Movie {activeMovie} deleted successfully.";
        TempData["ColorName"] = "danger";
        
        _service.DeleteMovie(activeMovie);
        
        return RedirectToAction("AllMovies");
    }

    [HttpGet("/movie/{movieId}/details")]
    public IActionResult MovieDetails(int movieId)
    {
        var viewModel = new MovieViewModel
        {
            Movie = _service.GetMovieById(movieId)
        };

        ViewBag.DetailsPage = "active";

        return View("Details", viewModel);
    }

    [HttpGet("/movie/{movieId}/manage")]
    public IActionResult ManageMovie(int movieId)
    {
        var viewModel = new ManageMovieViewModel
        {
            Movie = _service.GetMovieById(movieId),
            AllGenres = _service.GetAllGenres(),
            SelectedGenre = new Genre()
        };

        ViewBag.ManagePage = "active";

        return View("Manage", viewModel);
    }

    // GET
    [HttpPost("/movie/add-genre")]
    public RedirectToActionResult AddGenreToMovie(ManageMovieViewModel viewModel)
    {
        var movie = _service.GetMovieById(viewModel.Movie.MovieId);
        var genre = _service.GetGenreById(viewModel.SelectedGenre.GenreId);
        
        movie.Genres.Add(genre);
        _service.UpdateMovie(movie);
        
        return RedirectToAction("ManageMovie", new { movie.MovieId });
    }

    // POST
    [HttpPost("/movie/remove-genre")]
    public RedirectToActionResult RemoveGenreFromMovie(ManageMovieViewModel viewModel)
    {
        var movie = _service.GetMovieById(viewModel.Movie.MovieId);
        var genre = _service.GetGenreById(viewModel.SelectedGenre.GenreId);
        
        movie.Genres.Remove(genre);
        _service.UpdateMovie(movie);
        
        return RedirectToAction("ManageMovie", new { movie.MovieId });
    }
}