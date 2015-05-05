using System;
using System.Collections.Generic;
using RepairPartsCatalog.Business.ViewModels;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface ICarModelService : IBaseService
    {
        IEnumerable<CarModel> GetAll();

        CarModel GetById(long id);

        CarModelViewModel Create(CarModelViewModel carModel);

        CarModelTableViewModel GetTable(long? carBrandId);
    }
}