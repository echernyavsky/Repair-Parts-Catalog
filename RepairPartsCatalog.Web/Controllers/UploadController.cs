using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using RepairPartsCatalog.Business.Contracts;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RepairPartsCatalog.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly IExcelIntegrationService excelIntegrationService;
        private readonly ICountryService countryService;

        public UploadController(
            IExcelIntegrationService excelIntegrationService,
            ICountryService countryService
            )
        {
            this.excelIntegrationService = excelIntegrationService;
            this.countryService = countryService;
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
                var result = excelIntegrationService.LoadDataFromFile(stream);

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
    }
}
