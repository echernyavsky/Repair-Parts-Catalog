using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using RepairPartsCatalog.Business.Contracts;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RepairPartsCatalog.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly IExcelIntegrationService _excelIntegrationService;
        private readonly ICountryService countryService;
        private readonly ICsvCarIntegrationService carIntegrationService;

        public UploadController(
            IExcelIntegrationService _excelIntegrationService,
            ICountryService countryService,
            ICsvCarIntegrationService carIntegrationService
            )
        {
            this._excelIntegrationService = _excelIntegrationService;
            this.countryService = countryService;
            this.carIntegrationService = carIntegrationService;
        }


        // GET: /<controller>/
        public IActionResult ExcelFile()
        {
            return View();
        }

        [HttpPost]
        public IActionResult UploadExcelFile(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                var result = _excelIntegrationService.LoadDataFromFile(stream);

                if (result)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UploadCountryList()
        {
            return View("Country");
        }

        [HttpPost]
        public IActionResult UploadCountryList(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                countryService.UploadCsvList(stream);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult UploadVehicles()
        {
            return View("Vehicles");
        }

        [HttpPost]
        public IActionResult UploadVehicles(IFormFile file)
        {
            using (var stream = file.OpenReadStream())
            {
                carIntegrationService.LoadDataFromFile(stream);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
