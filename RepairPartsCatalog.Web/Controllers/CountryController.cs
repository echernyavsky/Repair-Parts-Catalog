using Microsoft.AspNet.Mvc;
using Newtonsoft.Json;
using RepairPartsCatalog.Business.Contracts;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RepairPartsCatalog.Web.Controllers
{
    public class CountryController : Controller
    {
        private readonly ICountryService countryService;

        public CountryController(
            ICountryService countryService)
        {
            this.countryService = countryService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var countryTable = countryService.GetCountryTable();
            return View(countryTable);
        }
    }
}
