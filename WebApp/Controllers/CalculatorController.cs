﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Form()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Result([FromForm] Calculator model)
    {
      
        if (!model.IsValid())
        {
            return View("Error");
        }
        return View(model);
    }
    
}

