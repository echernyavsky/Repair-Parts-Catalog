using System;
using System.Collections.Generic;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Services
{
    public class CarModelService : BaseService, ICarModelService
    {
        public CarModelService(ICatalogUoW catalogUow) : base(catalogUow)
        {
            
        }

        void ICarModelService.Create(CarModel carModel)
        {
            CatalogUow.CarModels.InsertOrUpdate(carModel);
            CatalogUow.Commit();
        }

        IEnumerable<CarModel> ICarModelService.GetAll()
        {
            var models = CatalogUow.CarModels.All();
            return models;
        }

        CarModel ICarModelService.GetById(long id)
        {
            var model = CatalogUow.CarModels.GetById(id);
            if (model == null)
            {
                throw new Exception(string.Format("Car Model with id = {0} not found in DB.", id));
            }

            return model;
        }
    }
}