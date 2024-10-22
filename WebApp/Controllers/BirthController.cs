using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class BirthController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}