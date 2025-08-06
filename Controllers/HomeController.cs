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
        return View();
    }
}
