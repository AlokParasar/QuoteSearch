using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using QuoteSearch.Models;
using Newtonsoft.Json;

namespace QuoteSearch.Controllers
{
    public class QuoteController : Controller
    {
        // GET: QuoteController
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// GET: QuoteController/Details/5
        /// </summary>
        /// <param name="QuoteId"></param>
        /// <returns></returns>
        public ActionResult Details()
        {
            return View();
        }

        /// <summary>
        /// GET: QuoteController/Search
        /// </summary>
        /// <returns></returns>
        public ActionResult Search()
        {
            var quote = new Quote();
            quote.StatusList = new List<string>();
            quote.StatusList.Add("Pending");
            quote.StatusList.Add("Issued");
            return View("Detail", quote);
        }

        /// <summary>
        /// GET: QuoteController/Search
        /// </summary>
        /// <param name="FirstName"></param>
        /// <param name="LastName"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Result(Quote quote)
        {
            var quoteList = new List<Quote>();

            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:49986/api/quote?FirstName=" + quote.FirstName + "&LastName=" + quote.LastName))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    quoteList = JsonConvert.DeserializeObject<List<Quote>>(apiResponse);
                }
            }

            return PartialView("_Search", quoteList);
        }

        /// <summary>
        /// GET: QuoteController/Search
        /// </summary>
        /// <param name="QuoteId"></param>
        /// <returns></returns>
        public async Task<IActionResult> Select(string QuoteId)
        {
            var insuredList = new List<AdditionalInsureds>();
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("http://localhost:49986/api/quote/GetInsureds?QuoteId=" + QuoteId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    insuredList = JsonConvert.DeserializeObject<List<AdditionalInsureds>>(apiResponse);
                }
            }
            return PartialView("_Detail", insuredList);
        }
    }
}
