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
  public IActionResult VerTareas()
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.VerTareas(id);
   
    return View("ListaTareas");
}
public IActionResult ModificarTarea(int idTarea)
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.ModificarTarea(idTarea);
   
    return View("Tarea");
}
public IActionResult FinalizarTarea(int idTarea)
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.FinalizarTarea(idTarea);
   
    return View("Tarea");
}

public IActionResult EliminarTarea(int idTarea)
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.EliminarTarea(idTarea);
   
    return View("Tarea");
}






public IActionResult AgregarTarea(int Id, string Titulo, string Descripcion,DateTime Fecha, bool Finalización, int IdUsuario)
{
Tarea NuevaTarea= new Tarea
{
    Id = Id,
    Titulo= Titulo,
    Descripcion= Descripcion,
    Fecha= Fecha,
    Finalización= Finalización,
    IdUsuario= IdUsuario ,
 
};
}
    public IActionResult Logout(){
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
      
    }
}

