using System;
using Microsoft.AspNetCore.Mvc;
using Lab3.Modells;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        private static Person p = new Person
        {
            FirstName = "Rob",
            LastName = "Monzo",
            Age = 22,
            BirthDate = new DateTime(1994, 9, 7)

        };

        public IActionResult Index()
        {
            //12AM Hours of 12AM - 12PM
            DateTime morningDate = new DateTime(2017, 1, 1, 0, 0, 0);
            TimeSpan morningTime = morningDate.TimeOfDay; //pulls time from morning

            //12PM  Hours of 12PM - 6PM
            DateTime afternoonDate = new DateTime(2017, 1, 1, 12, 00, 00);
            TimeSpan afternoonTime = afternoonDate.TimeOfDay; //pulls time from afternoon

            //6PM Hours of 6PM - 12 AM
            DateTime eveningDate = new DateTime(2017, 1, 1, 18, 0, 0);
            TimeSpan eveningTime = eveningDate.TimeOfDay; //pulls time from evening

            //current Date/time 
            DateTime current = DateTime.Now;
            TimeSpan currentTime = current.TimeOfDay; //Pulls time from current


            string currentMessage = "";
            if (currentTime >= morningTime && currentTime < afternoonTime) //If it is the morning, display Good Morning! (Between 12AM-12PM)
            {
                currentMessage = "Good Morning!";
            }
            else if (currentTime >= afternoonTime && currentTime < eveningTime)//If it is the afternoon, display Good Afternoon!
            {
                currentMessage = "Good Afternoon!";
            }
            else if (currentTime >= eveningTime) //If it is the evening, display Good Evening!
            {
                currentMessage = "Good Evening!";
            }

            //January 1st 2018 -- at 12 in the morning -- the earliest possible time in the new year
            DateTime upcomingYear = new DateTime(2018, 1, 1, 0, 0, 0);
            DateTime today = DateTime.Today;


            double daysUntilNextYear = (upcomingYear - today).TotalDays;

            //Calculations
            GreetingModel message = new GreetingModel
            {
                Time = current.TimeOfDay.Hours.ToString() + ":" + current.TimeOfDay.Minutes.ToString(),
                DayOfWeek = current.DayOfWeek.ToString(),
                Day = current.Day.ToString(),
                Month = current.Month.ToString(),
                Year = current.Year.ToString(),
                DayMessage = currentMessage,
                DaysLeftNextYears = daysUntilNextYear

            };
            return View(message);
         }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


        public IActionResult ShowPerson()
        {

            return View(p);
        }

        private IActionResult ShowPerson(Person p)
        {
            {
                return View(p);
            }
        }

        public IActionResult AddPerson()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddPerson(Person person)
        {
            if (ModelState.IsValid)
            {
                p.FirstName = person.FirstName;
                p.LastName = person.LastName;
                p.Age = person.Age;
                p.BirthDate = person.BirthDate;


                return RedirectToAction("ShowPerson");

            }
            else
            {
                return View();
            }

        }
    }
}
