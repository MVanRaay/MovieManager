using Microsoft.EntityFrameworkCore;

namespace MovieManager.Entities;

public class MovieManagerDbContext : DbContext
{
    public MovieManagerDbContext(DbContextOptions<MovieManagerDbContext> options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<MovieGenre> MovieGenres { get; set; }
    public DbSet<Genre> Genres { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies).UsingEntity<MovieGenre>();
        modelBuilder.Entity<Movie>().HasData(
            new Movie
            {
                MovieId = 1,
                Title = "The Godfather",
                Description =
                    "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
                MpaRating = MpaRating.Restricted,
                Rating = 9.2,
                Year = 1972,
                Duration = 175
            },
            new Movie
            {
                MovieId = 2,
                Title = "Cars 3",
                Description =
                    "Lightning McQueen sets out to prove to a new generation of racers that he's still the best race car in the world.",
                MpaRating = MpaRating.GeneralAudiences,
                Rating = 6.7,
                Year = 2017,
                Duration = 102
            },
            new Movie
            {
                MovieId = 3,
                Title = "Spider-Man: Into the Spider-Verse",
                Description =
                    "Teen Miles Morales becomes the Spider-Man of his universe and must join with five spider-powered individuals from other dimensions to stop a threat for all realities.",
                MpaRating = MpaRating.ParentalGuidanceSuggested,
                Rating = 8.4,
                Year = 2018,
                Duration = 117
            }
        );

        modelBuilder.Entity<Genre>().HasMany(g => g.Movies).WithMany(m => m.Genres).UsingEntity<MovieGenre>();
        modelBuilder.Entity<Genre>().HasData
        (
            new Genre
            {
                GenreId = 1,
                Name = "Gangster"
            },
            new Genre
            {
                GenreId = 2,
                Name = "Animated"
            }
        );

        modelBuilder.Entity<MovieGenre>().HasData
        (
            new MovieGenre
            {
                MovieId = 1,
                GenreId = 1,
            },
            new MovieGenre
            {
                MovieId = 2,
                GenreId = 2,
            },
            new MovieGenre
            {
                MovieId = 3,
                GenreId = 2,
            }
        );
    }
}