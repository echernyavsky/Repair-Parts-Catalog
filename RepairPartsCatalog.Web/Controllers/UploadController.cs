using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using RepairPartsCatalog.Business.Contracts;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RepairPartsCatalog.Web.Controllers
{
    public class UploadController : Controller
    {
        private readonly IExcelIntegrationService excelIntegrationService;

        public UploadController(IExcelIntegrationService excelIntegrationService)
        {
            this.excelIntegrationService = excelIntegrationService;
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
    }
}
