using System;
using System.Collections.Generic;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;
using RepairPartsCatalog.Business.ViewModels;
using Mapper;
using System.Linq;

namespace RepairPartsCatalog.Business.Services
{
    public class CarTypeService : BaseService, ICarTypeService
    {
        public CarTypeService(ICatalogUoW catalogUow) : base(catalogUow) { }

        IEnumerable<CarTypeViewModel> ICarTypeService.GetAll()
        {
            var carTypes = CatalogUow.CarTypes.All().ToList();
            return EntityMapper.Map(carTypes);
        }
    }
}