using Microsoft.AspNetCore.Mvc;
using Lab3.Modells;

namespace Lab4.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ShowPerson(Person input)
        {
            if (ModelState.IsValid)
            {
                ViewData["FirstName"] = input.FirstName;
                ViewData["LastName"] = input.LastName;
                ViewData["Birthdate"] = input.BirthDate;

                return View(input);
            }
            return View(input);
        }
    }
}