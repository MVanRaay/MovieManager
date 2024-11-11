namespace MovieManager.Entities;

public class MovieActor
{
    public int MovieId { get; set; }
    public int ActorId { get; set; }
    public List<Movie> Movies { get; set; }
    public List<Actor> Actors { get; set; }
}