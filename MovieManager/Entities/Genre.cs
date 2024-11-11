using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieManager.Entities;

public class Genre
{
    public int GenreId { get; set; }
    
    [Required(ErrorMessage = "Genre name is required")]
    public string? Name { get; set; }
    
    [ValidateNever]
    public List<MovieGenre>? MovieGenres { get; set; }
    public List<Movie>? Movies { get; set; }
}