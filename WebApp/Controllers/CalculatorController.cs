using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Result(Operator? op, double? x, double? y)
    {
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
}

