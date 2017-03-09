using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab3.Modells
{
    public class Person
    {
        public int PersonId { get; set; }
        [Required(ErrorMessage = "Please provide a name")]
        [StringLength(20, MinimumLength = 2)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BirthDate { get; set; }
        public int Age
        {
            get
            {
                DateTime BirthDay = DateTime.Parse(BirthDate);

                var now = DateTime.Today;
                int age = now.Year - BirthDay.Year;
                if (BirthDay > now.AddYears(-age)) age--; ;
                return age;
            }
        }

        public List<Person> Persons { get; set; }
    }

}