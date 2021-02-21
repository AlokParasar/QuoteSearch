using System;

namespace QuoteSearch.Models
{
    public class Person
    {
        public string PersonId { get; set; }

        public string FirstName { get; set; }

        public string Name => FirstName + " " + LastName;

        public string LastName { get; set; }

        public DateTime DateOfBirth => DateTime.Now;
    }
}
