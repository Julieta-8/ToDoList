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
    ViewBag.Tareas = BD.VerTareas(idTarea);
   
    return View("ListaTarea");
}
public IActionResult VerTareas()
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.VerTareas(id);
   
    return View("ListaTareas");
}
public IActionResult FinalizarTarea(){
return View("Finalizar");
}
public IActionResult GuardarFinalizarTarea(int idTarea)
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.FinalizarTarea(idTarea);
   
    return View("Tarea");
}
public IActionResult EliminarTarea(){
return View("Eliminar");
}
public IActionResult GuardarEliminarTarea(int idTarea)
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.EliminarTarea(idTarea);
   
    return View("Tarea");
}

public IActionResult AgregarTarea(){
return View("Agregar");
}
public IActionResult GuardarAgregarTarea(int Id, string Titulo, string Descripcion,DateTime Fecha, bool Finalización, int IdUsuario)
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
 int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.AgregarTarea(NuevaTarea);
   
    return View("Tarea");
}


}