using Microsoft.AspNet.Mvc;
using RepairPartsCatalog.Business.Contracts;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace RepairPartsCatalog.Web.Controllers
{
    public class CarModificationController : Controller
    {
        private readonly ICarModificationService carModificationService;

        public CarModificationController(ICarModificationService carModificationService)
        {
            this.carModificationService = carModificationService;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var carModifications = carModificationService.GetAll();
            return View(carModifications);
        }
    }
}
