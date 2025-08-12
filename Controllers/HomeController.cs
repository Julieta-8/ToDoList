using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListmaster.Models;

namespace ToDoListmaster.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult VerTarea(int idTarea)
    {
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tarea = BD.GetUsuario(idTarea); 
   
    return View("Tarea");
    }
    public IActionResult Logout(){
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
      
    }
}
