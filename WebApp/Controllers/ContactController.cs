using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Services;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    // GET // Lista kontaków, przycisk dodawania kontaktu
    public ActionResult Index()
    {
        return View(_contactService.GetAll());
    }

    public ActionResult Details(int id)
    {
        return View(_contactService.GetById(id));
    }

    // formularz dodawania kontaktu
    public IActionResult Add()
    {
        return View();
    }
    // odebranie danych z formularza, walidacja i dodanie kontaktu do kolekcji
    [HttpPost]
    public IActionResult Add(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

       
        // dodanie modelu do kolekcji
        _contactService.Add(model);
        return RedirectToAction(nameof(Index));
    }

    public ActionResult Edit(int id)
    {
        return View(_contactService.GetById(id));
    }

    [HttpPost]
    public ActionResult Edit(ContactModel model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        _contactService.Update(model);
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int id)
    {
        
        return RedirectToAction(nameof(Index));
    }
}