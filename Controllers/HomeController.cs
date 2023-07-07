using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TestDemo.Models;

namespace TestDemo.Controllers;

public class SomeData
{
    public string Name { get; set; }
    public int Age { get; set; }
}

public static class DB
{
    public static string Name { get; set; }
    public static int Age { get; set; }
}

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        @ViewData["Name"] = DB.Name ?? "default";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpPost]
    public ActionResult SetData(SomeData someData)
    {
        Console.WriteLine("User set data: " + someData.Name);
        DB.Name = someData.Name;
        DB.Age = someData.Age;
        @ViewData["Name"] = DB.Name;
        @ViewData["Age"] = DB.Age;
        return View("Index");
    }
}