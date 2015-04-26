using System.Collections.Generic;
using RepairPartsCatalog.Business.ViewModels;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface ICarTypeService
    {
        IEnumerable<CarTypeViewModel> GetAll();
    }
}