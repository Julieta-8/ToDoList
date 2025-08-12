using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
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


  [HttpPost]public IActionResult SignUpGuardar(string UserName, string Contraseña)
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
        return View("CrearCuenta");
    }
}
  
}