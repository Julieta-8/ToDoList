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
    ViewBag.Tareas = BD.VerTarea(idTarea);
   
    return View("ListaTarea");
}

public IActionResult VerTareas()
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.VerTareas(id);
    
    return View("ListaTareas");
}

public IActionResult GuardarFinalizarTarea(int idTarea,bool finalizada)
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.FinalizarTarea( idTarea,  finalizada);
   
    return View("ListaTareas");
}

public IActionResult GuardarEliminarTarea(int idTarea)
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    ViewBag.Tareas = BD.EliminarTarea(idTarea);
   
    return View("ListaTareas");
}

public IActionResult AgregarTarea(){
return View("Agregar");
}
public IActionResult GuardarAgregarTarea(int Id, string Titulo, string Descripcion,DateTime Fecha, bool Finalizada, int IdUsuario)
{
Tarea NuevaTarea= new Tarea
{
    Id = Id,
    Titulo= Titulo,
    Descripción= Descripcion,
    Fecha= Fecha,
    Finalizada= Finalizada,
    IdUsuario= IdUsuario ,
 
};
 int id = int.Parse(HttpContext.Session.GetString("idUser"));
BD.AgregarTarea(NuevaTarea);
ViewBag.Tareas =BD.VerTarea(Id);
   
    return View("Cuenta");
}
public IActionResult ModificarTarea(int idtarea){
    Tarea t= BD.VerTarea(idtarea);
    ViewBag.Tarea = t;
return View("Modificar");
}
public IActionResult GuardarModificarTarea(int Id, int idu,string Titulo, string Descripcion,DateTime Fecha, bool Finalización)
{
int id = int.Parse(HttpContext.Session.GetString("idUser"));
Tarea NuevaTarea= new Tarea
{
    Id = Id,
    Titulo= Titulo,
    Descripción= Descripcion,
    Fecha= Fecha,
    Finalizada= Finalización,
    IdUsuario= idu,
 
};


    
    ViewBag.Tareas = BD.ModificarTarea(NuevaTarea);
   
    return View("ListaTareas");
}

}
  

 


