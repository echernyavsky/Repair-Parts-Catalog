using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface ICarTypeService
    {
        IEnumerable<CarType> GetAll();
    }
}