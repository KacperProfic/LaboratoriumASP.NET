using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class ContactController : Controller
{
    private static Dictionary<int, ContactModel> _contacts = new()
    {
        {
            1,
            new ContactModel()
            {
                Id = 1,
                FirstName = "Adam",
                LastName = "Abecki",
                Email = "adam@wsei.edu.pl",
                PhoneNumber = "222 333 222",
                BirthDate = new DateOnly(2000,10,10)
            }
            
        },
        {
            2,
            new ContactModel()
            {
                Id = 2,
                FirstName = "Ewa",
                LastName = "Sala",
                Email = "ewa@wsei.edu.pl",
                PhoneNumber = "212 343 222",
                BirthDate = new DateOnly(2002, 03, 01)
            }
            
        },

    };

    private static int currentId = 3;
    // GET // Lista kontaków, przycisk dodawania kontaktu
    public IActionResult Index()
    {
        return View(_contacts);
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

        model.Id = ++currentId;
        _contacts.Add(model.Id, model);
        // dodanie modelu do kolekcji
        return View("Index", _contacts);
    }

    public IActionResult Delete(int id)
    {
        _contacts.Remove(id);
        return View("Index", _contacts);
    }
}