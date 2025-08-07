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
    public IActionResult VerTarea()
    {
        return View ("VerTarea");
    }
}
