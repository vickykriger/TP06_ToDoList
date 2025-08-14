using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using Dapper;

namespace ToDoList.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return RedirectToAction("Login", "Account");
    }
    public IActionResult VerTareas()
    {
        return View ("VerTareas");
    }
    public IActionResult VerTarea(int id)
    {
        ViewBag.id = id;
        return View ("VerTarea");
    }
    public IActionResult CrearTarea()
    {
        return View ("CrearTarea");
    }

    public IActionResult CrearTareaGuardar(string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
        int id = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("user")).id;
        Tarea tarea = new Tarea (titulo, descripcion, fecha, finalizada, id);
        BD.crearTarea(tarea);
        return View ("VerTareas");
    }
    public IActionResult ModificarTarea(int id)
    {
        ViewBag.tarea=BD.devolverTarea(id);
        return View ("ModificarTareas");
    }
    public IActionResult ModificarTareaGuardar(int id, string titulo, string descripcion, DateTime fecha, bool finalizada)
    {
        int idUser = Objeto.StringToObject<Usuario>(HttpContext.Session.GetString("user")).id;
        BD.modificarTarea(id, titulo, descripcion, fecha, finalizada, idUser);
        return View ("VerTareas");
    }
    public IActionResult EliminarTarea(int id)
    {
        BD.eliminarTarea(id);
        return View ("VerTareas");
    }   

    public IActionResult FinalizarTarea(int id) 
    {
        BD.finalizarTarea(id);
        return View ("VerTareas");
    }

}
