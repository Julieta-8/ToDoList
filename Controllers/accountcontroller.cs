using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListmaster.Models;
namespace ToDoListmaster.Controllers;
public class accountController : Controller

{
     [HttpPost]public IActionResult LoginGuardar(string UserName, string Contraseña)
{
    int id = BD.Login(UserName, Contraseña);

    if (id != -1)
    {
        HttpContext.Session.SetString("idUser", id.ToString());
        ViewBag.Usuario = BD.GetUsuario(id);
         return RedirectToAction("ListarTareas", "Home");
    }
    else
    {
        ViewBag.Error = "Login incorrecto";
        return View("IniciarSesión");
    }
}

public IActionResult Login()
{
        return View("IniciarSesión");
}

public IActionResult SignUp()
{
        return View("CrearCuenta");
       
}

public IActionResult SignUpGuardar(string UserName, string nombre, string apellido,  string contrasena)
{
    int id = BD.RegistrarUsuario(  nombre,  apellido,   contrasena, UserName);

  
        HttpContext.Session.SetString("idUser", id.ToString());
         
        return View("ListaTareas");
   
}
      public IActionResult Logout(){
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
      
    }

    public IActionResult GuardarActualizarLogIn()
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    BD.ActualizarFecha(id);
   
    return View("ListaTareas");
}
   public IActionResult InfoUsuario()
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
      ViewBag.Usuario = BD.GetUsuario(id);
    return View("InfoUsuario");
}
public IActionResult Volver(){
    
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
        return RedirectToAction("ListarTareas", "Home");
}
}
