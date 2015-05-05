using System;
using System.Collections.Generic;
using System.Linq;
using Mapper;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Business.ViewModels;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Services
{
    public class CarModelService : BaseService, ICarModelService
    {
        public CarModelService(ICatalogUoW catalogUow) : base(catalogUow)
        {
            
        }

        CarModelViewModel ICarModelService.Create(CarModelViewModel carModel)
        {
            var entity = EntityMapper.Map(carModel);
            CatalogUow.CarModels.InsertOrUpdate(entity);
            CatalogUow.Commit();

            var updated = ((ICarModelService)(this)).GetById(entity.Id);
            return EntityMapper.Map(updated);
        }

        IEnumerable<CarModel> ICarModelService.GetAll()
        {
            var models = CatalogUow.CarModels.All();
            return models;
        }

        CarModel ICarModelService.GetById(long id)
        {
            var model = CatalogUow.CarModels.All()
                .Include(it => it.CarBrand)
                .Include(it => it.CarType)
                .FirstOrDefault(it => it.Id == id);

            if (model == null)
            {
                throw new Exception(string.Format("Car Model with id = {0} not found in DB.", id));
            }

            return model;
        }

        CarModelTableViewModel ICarModelService.GetTable(long? carBrandId)
        {
            var carModels = CatalogUow.CarModels.All()
                .Include(it => it.CarType)
                .Include(it => it.CarBrand);

            var table = new CarModelTableViewModel();

            table.Models = carBrandId.HasValue ? 
                carModels.Where(it => it.CarBrandId == carBrandId).Select(EntityMapper.Map).ToList() : 
                carModels.Select(EntityMapper.Map).ToList();
            table.Brands = CatalogUow.CarBrands.All()
                .Include(it => it.Country)
                .OrderBy(it => it.Name)
                .Select(EntityMapper.Map)
                .ToList();
            table.Types = CatalogUow.CarTypes.All().OrderBy(it => it.Name).Select(EntityMapper.Map).ToList();

            return table;
        }
    }
}