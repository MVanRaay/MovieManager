using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace MovieManager.Entities;

public enum MpaRating
{
    NotYetRated,
    GeneralAudiences,
    ParentalGuidanceSuggested,
    ParentsStronglyCautioned,
    Restricted,
    AdultsOnly,
    Unrated
}

public class Movie
{
    public int MovieId { get; set; }
    
    [Required(ErrorMessage = "Title is required")]
    public string? Title { get; set; }
    
    [Required(ErrorMessage = "Description is required")]
    public string? Description { get; set; }
    
    public MpaRating MpaRating { get; set; } = MpaRating.NotYetRated;
    
    [Required(ErrorMessage = "Rating is required")]
    [Range(1, 10, ErrorMessage = "Rating must be between 1 and 10")]
    public double Rating { get; set; }
    
    [Required(ErrorMessage = "Year is required")]
    [Range(1920, 2024, ErrorMessage = "Year must be between 1920 and 2024")]
    public int Year { get; set; }
    
    [Required(ErrorMessage = "Duration is required")]
    [Range(1, 1440, ErrorMessage = "Duration must be between 1 and 1440")]
    public int Duration { get; set; }
    
    [ValidateNever]
    public List<MovieGenre>? MovieGenres { get; set; }
    public List<Genre>? Genres { get; set; }
    
    // [Required(ErrorMessage = "Genre is required")]
    // public int GenreId { get; set; }
    //
    // [ValidateNever]
    // public Genre? Genre { get; set; }
}