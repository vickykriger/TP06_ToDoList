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

    public IActionResult Index()
    {
        return View();
    }
}
