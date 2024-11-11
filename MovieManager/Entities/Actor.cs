namespace MovieManager.Entities;

public class Actor
{
    public int ActorId { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public int Height { get; set; }
    public DateTime? BirthDate { get; set; }
    public List<Movie>? Movies { get; set; }
    public List<Movie>? MovieActors { get; set; }
}