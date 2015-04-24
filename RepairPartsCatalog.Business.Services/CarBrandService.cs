using System;
using System.Collections.Generic;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;
using RepairPartsCatalog.Business.ViewModels;
using AutoMapper;

namespace RepairPartsCatalog.Business.Services
{
    public class CarBrandService : BaseService, ICarBrandService
    {
        public CarBrandService(ICatalogUoW catalogUow) : base(catalogUow)
        {
            
        }

        void ICarBrandService.Create(CarBrandViewModel carBrand)
        {
            var brand = Mapper.Map<CarBrandViewModel, CarBrand>(carBrand);
            CatalogUow.CarBrands.InsertOrUpdate(brand);
            CatalogUow.Commit();
        }

        IEnumerable<CarBrandViewModel> ICarBrandService.GetAll()
        {
            var brands = CatalogUow.CarBrands.All();
            return Mapper.Map<IEnumerable<CarBrand>, IEnumerable<CarBrandViewModel>>(brands);
        }

        CarBrandViewModel ICarBrandService.GetById(long id)
        {
            var brand = CatalogUow.CarBrands.GetById(id);
            if (brand == null)
            {
                throw new Exception(string.Format("Can't find car brand with id = {0} in DB.", id));
            }

            return Mapper.Map<CarBrand, CarBrandViewModel>(brand);
        }
    }
}