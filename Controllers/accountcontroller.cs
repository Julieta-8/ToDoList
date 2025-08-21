using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListmaster.Models;
namespace ToDoListmaster.Controllers;
public class accountController : Controller

{
     [HttpPost]public IActionResult LoginGuardar(string UserName, string Contraseña)
{
    Usuario u = BD.Login(UserName, Contraseña);

    if (u != null)
    {
        HttpContext.Session.SetString("idUser", u.ToString());
        
        return View("ListarTareas");
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

public IActionResult SignUpGuardar(string UserName, string nombre, string apellido, string email, string contrasena)
{
    int id = BD.RegistrarUsuario( nombre,  apellido,  email,  contrasena, UserName);

  
        HttpContext.Session.SetString("idUser", id.ToString());
         
        return View("Cuenta");
   
}
      public IActionResult Logout(){
      HttpContext.Session.Clear();
      return RedirectToAction("Index");
      
    }

    public IActionResult GuardarActualizarLogIn()
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
    BD.ActualizarFecha(id);
   
    return View("Cuenta");
}
   public IActionResult InfoUsuario()
{
    int id = int.Parse(HttpContext.Session.GetString("idUser"));
      ViewBag.Usuarop = BD.VerUsuario(id);
    return View("InfoUsuario");
}

}
