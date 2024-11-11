using Microsoft.AspNetCore.Mvc;

namespace MovieManager.Controllers;

public class ActorsController : Controller
{
    // GET
    [HttpGet("/actors/all")]
    public IActionResult Index()
    {
        return View();
    }
}