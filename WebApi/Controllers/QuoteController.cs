using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using QuoteSearch.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        /// <summary>
        /// GET api/values/Q93248
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<List<Quote>> GetQuote(string FirstName, string LastName)
        {   
            return GetDummyQuoteData(FirstName, LastName);
        }

        /// <summary>
        /// Get Additional Insureds
        /// </summary>
        /// <param name="QuoteId"></param>
        /// <returns></returns>
        [Route("GetInsureds")]
        [HttpGet]
        public ActionResult<List<AdditionalInsureds>>GetAdditionalInsureds(string QuoteId)
        { 
            return GetDummyPersonData(QuoteId);
        }

        /// <summary>
        /// Get Dummy Quote Data
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        private List<Quote> GetDummyQuoteData(string FirstName, string LastName)
        {
            var quoteList = new List<Quote>();
            var person = new Person {
                PersonId = "1",
                FirstName = FirstName,
                LastName = LastName
            };

            var quote = new Quote
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                QuoteId = "0"
            };
            quoteList.Add(quote);

            person = new Person
            {
                PersonId = "2",
                FirstName = "Mr. John",
                LastName = "Krakow"
            };
            quote = new Quote
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                QuoteId = "1"
            };
            quoteList.Add(quote);

            person = new Person
            {
                PersonId = "3",
                FirstName = "Mr. Red",
                LastName = "Hemmington"
            };
            quote = new Quote
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                QuoteId = "2"
            };
            quoteList.Add(quote);
            return quoteList;
        }

        /// <summary>
        /// Get Dummy Person Data
        /// </summary>
        /// <param name="QuoteId"></param>
        /// <returns></returns>
        private List<AdditionalInsureds> GetDummyPersonData(string QuoteId)
        {
            var insuredList = new List<AdditionalInsureds>();
            var addtionalInsured = new AdditionalInsureds
            {
                AdditionalInsuredId = "1",
                PersonId = "1",
                QuoteId = QuoteId
            };

            var person = new Person
            {
                PersonId = "11",
                FirstName = "Mr. Ron",
                LastName = "Endrich"
            };

            var insured = new AdditionalInsureds
            {
                Name = person.Name,
                DateOfBirth = person.DateOfBirth,
                Coverage = 90,
                QuoteId = addtionalInsured.QuoteId
            };
            insuredList.Add(insured);


            addtionalInsured = new AdditionalInsureds
            {
                AdditionalInsuredId = "2",
                PersonId = "12",
                QuoteId = "1"
            };

            person = new Person
            {
                PersonId = "12",
                FirstName = "Mr. Thom",
                LastName = "Crystal"
            };
            insured = new AdditionalInsureds
            {
                Name = person.Name,
                DateOfBirth = person.DateOfBirth,
                Coverage = 100,
                QuoteId = addtionalInsured.QuoteId
            };
            insuredList.Add(insured);
            return insuredList;
        }
    }
}
