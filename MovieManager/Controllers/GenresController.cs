﻿using Microsoft.AspNetCore.Mvc;
using MovieManager.Entities;
using MovieManager.Models;
using MovieManager.Services;

namespace MovieManager.Controllers;

public class GenresController : Controller
{
    private readonly IMovieManagerService _service;

    public GenresController(IMovieManagerService service)
    {
        _service = service;
    }
    
    // GET
    [HttpGet("/genres/all")]
    public IActionResult AllGenres()
    {
        GenresViewModel viewModel = new GenresViewModel
        {
            Genres = _service.GetAllGenres()
        };

        ViewBag.AllPage = "active";
        
        return View("All", viewModel);
    }
    
    // GET
    [HttpGet("/genre/add")]
    public IActionResult AddGenre()
    {
        GenreViewModel viewModel = new GenreViewModel
        {
            Genre = new Genre()
        };
        
        ViewBag.AddPage = "active";
        
        return View("Add", viewModel);
    }

    // POST
    [HttpPost("/genre/add")]
    public IActionResult AddGenre(GenreViewModel viewModel)
    {
        if (!ModelState.IsValid) return View("Add", viewModel);
        
        _service.AddGenre(viewModel.Genre);
        
        TempData["Message"] = $"Genre \"{viewModel.Genre.Name}\" added successfully.";
        TempData["ColorName"] = "success";
        
        return RedirectToAction("AllGenres");
    }
    
    // GET
    [HttpGet("/genre/{genreId}/edit")]
    public IActionResult EditGenre(int genreId)
    {
        GenreViewModel viewModel = new GenreViewModel
        {
            Genre = _service.GetGenreById(genreId)
        };

        ViewBag.EditPage = "active";
        
        return View("Edit", viewModel);
    }
    
    // POST
    [HttpPost("/genre/{genreId}/edit")]
    public IActionResult EditGenre(GenreViewModel viewModel)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.EditPage = "active";
            return View("Edit", viewModel);
        }
        
        _service.UpdateGenre(viewModel.Genre);
        
        TempData["Message"] = $"Genre \"{viewModel.Genre.Name}\" updated successfully.";
        TempData["ColorName"] = "success";
        
        return RedirectToAction("AllGenres");
    }
    
    // GET
    [HttpGet("/genre/{genreId}/delete")]
    public ViewResult DeleteGenre(int genreId)
    {
        var viewModel = new GenreViewModel
        {
            Genre = _service.GetGenreById(genreId)
        };
        
        ViewBag.DeletePage = "active";
        
        return View("Delete", viewModel);
    }
    
    // POST
    [HttpPost("/genre/{genreId}/delete")]
    public RedirectToActionResult DeleteGenre(GenreViewModel viewModel)
    {
        TempData["Message"] = $"Genre \"{viewModel.Genre.Name}\" deleted successfully.";
        TempData["ColorName"] = "danger";
        
        _service.DeleteGenre(viewModel.Genre);
        
        return RedirectToAction("AllGenres");
    }
}