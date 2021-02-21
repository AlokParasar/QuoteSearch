using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace QuoteSearch.Models
{
    public class Quote
    {
        public string QuoteId { get; set; }

        public double Coverage { get; set; }

        [Display(Name = "Status")]
        public List<string> StatusList { get; set; }

        public string Status { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Name => FirstName + " " + LastName;

        public string DoB => DateOfBirth.ToShortDateString();

        public DateTime DateOfBirth { get; set; }
    }
}
