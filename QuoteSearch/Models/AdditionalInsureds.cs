using System;

namespace QuoteSearch.Models
{
    public class AdditionalInsureds
    {
        public string AdditionalInsuredId { get; set; }

        public string PersonId { get; set; }

        public string QuoteId { get; set; }

        public DateTime DateOfBirth { get; set; }

        public double Coverage { get; set; }

        public string Name { get; set; }

        public string DoB => DateOfBirth.ToShortDateString();
    }
}
