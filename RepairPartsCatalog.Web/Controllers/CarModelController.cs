using Microsoft.AspNet.Mvc;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Business.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RepairPartsCatalog.Web.Controllers
{
    public class CarModelController : Controller
    {
        private readonly ICarModelService carModelService;

        public CarModelController(ICarModelService carModelService)
        {
            this.carModelService = carModelService;
        }

        // GET: /<controller>/
        public IActionResult Index(long? brandId)
        {
            var table = carModelService.GetTable(brandId);
            return View(table);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CarModelViewModel model)
        {
            var carModel = carModelService.Create(model);
            return Json(carModel);
        }
    }
}
