using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Dapper;

namespace ToDoList.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Login()
    {
        return View("Login");
    }
    public IActionResult LoginGuardar(string username, string password)
    {
        Usuario user = BD.login(username, password);
        if(user==null)
        {
            return View("Login");
        }
        else 
        {
            BD.actualizarLogin(user.id);
            HttpContext.Session.SetString("user", Objeto.ObjectToString(user));
            return RedirectToAction("VerTareas", "Home");
        }
    }
    public IActionResult Registro()
    {
        return View("Registro");
    }
    public IActionResult RegistroGuardar(string username, string password, string nombre, string apellido, string foto)
    {
        Usuario user = new Usuario(username, password, nombre, apellido, foto);
        bool registrado = BD.registrarse(user);
        if(registrado)
        {
            return View ("Login");
        }
        else
        {
            return View ("Registro");
        }
    }
    public IActionResult cerrarSesion()
    {
        HttpContext.Session.Remove("user");
        return View("Login");
    }
}
