using System;
using System.Collections.Generic;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Services
{
    public class CarTypeService : BaseService, ICarTypeService
    {
        public CarTypeService(ICatalogUoW catalogUow) : base(catalogUow) { }

        IEnumerable<CarType> ICarTypeService.GetAll()
        {
            var carTypes = CatalogUow.CarTypes.All();
            return carTypes;
        }
    }
}