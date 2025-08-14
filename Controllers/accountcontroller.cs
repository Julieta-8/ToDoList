using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoListmaster.Models;
namespace ToDoListmaster.Controllers;
public class AccountController : Controller

{
     [HttpPost]public IActionResult LoginGuardar(string UserName, string Contraseña)
{
    Usuario u = BD.Login(UserName, Contraseña);

    if (u != null)
    {
        HttpContext.Session.SetString("idUser", u.ToString());
          ViewBag.Usuario = BD.Login(UserName, Contraseña);
        return View("Cuenta");
    }
    else
    {
        ViewBag.Error = "Login incorrecto";
        return View("IniciarSesión");
    }
}

[HttpPost]public IActionResult Login()
{
        return View("IniciarSesión");
    
}

[HttpPost]public IActionResult SignUp()
{
        return View("CrearCuenta");
    
}


  [HttpPost]public IActionResult SignUpGuardar(string UserName, string nombre, string apellido, string email, string contrasena)
{
    int id = BD.RegistrarUsuario( nombre,  apellido,  email,  contrasena, UserName);

  
        HttpContext.Session.SetString("idUser", id.ToString());
          ViewBag.Usuario = BD.Login(UserName, contrasena);
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


}
