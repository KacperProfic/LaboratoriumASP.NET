using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult About()
    {
        return View();
    }
        //Zadanie 2 dodaj do kalkulatora: operator pow(podnosi x do potegi y), funckje sin ktora oblicza sin(x), y jest zbedne
      
    public IActionResult Calculator(Operator? op, double? x, double? y)
    {
        //var op = Request.Query["op"];
       // var x = double.Parse(Request.Query["x"]);
        //var y = double.Parse(Request.Query["y"]);
        if (x is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze x";
            return View("CalculatorError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator!";
            return View("CalculatorError");
        }

        
        if (op != Operator.Sin && y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby w parametrze y";
            return View("CalculatorError");
        }

        switch (op)
        {
            case Operator.Add:
                ViewBag.Result = x + y;
                break;
            case Operator.Sub:
                ViewBag.Result = x - y;
                break;
            case Operator.Mul:
                ViewBag.Result = x * y;
                break;
            case Operator.Div:
                ViewBag.Result = x / y;
                break;
            case Operator.Pow:
                ViewBag.Result = Math.Pow((double)x, (double)y);
                break;
            case Operator.Sin:
                ViewBag.Result = Math.Sin((Math.PI / 180) * (double)x);
                break;
            
                
            
        }

        return View();
    }

    public IActionResult Index()
    {
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
}

public enum Operator
{
    Add, Sub, Mul, Div, Pow, Sin
}