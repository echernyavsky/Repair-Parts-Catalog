using System;
using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface ICarModelService : IBaseService
    {
        IEnumerable<CarModel> GetAll();

        CarModel GetById(long id);

        void Create(CarModel carModel);
    }
}