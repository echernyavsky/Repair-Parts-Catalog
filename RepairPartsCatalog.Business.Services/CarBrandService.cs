using System;
using System.Collections.Generic;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;
using RepairPartsCatalog.Business.ViewModels;
using System.Linq;
using Mapper;

namespace RepairPartsCatalog.Business.Services
{
    public class CarBrandService : BaseService, ICarBrandService
    {
        private readonly ICarTypeService carTypeService;
        private readonly ICountryService countryService;

        public CarBrandService(
            ICatalogUoW catalogUow,
            ICountryService countryService,
            ICarTypeService carTypeService)
            : base(catalogUow)
        {
            this.carTypeService = carTypeService;
            this.countryService = countryService;
        }

        CarBrandViewModel ICarBrandService.Create(CarBrandViewModel carBrand)
        {
            var brand = EntityMapper.Map(carBrand);
            CatalogUow.CarBrands.InsertOrUpdate(brand);
            CatalogUow.Commit();

            var newBrand = CatalogUow.CarBrands.All().Include(it => it.Country).First(it => it.Id == brand.Id);
            return EntityMapper.Map(newBrand);
        }

        IEnumerable<CarBrandViewModel> ICarBrandService.GetAll()
        {
            var brands = CatalogUow.CarBrands.All()
                .Include(it => it.Country)
                .OrderBy(it => it.Name);
            return EntityMapper.Map(brands);
        }

        CarBrandTableViewModel ICarBrandService.GetCarBrandsTable(CarTypeViewModel model = null)
        {
            var brands = CatalogUow.CarBrands.All()
                .OrderBy(it => it.Name)
                .Include(it => it.Country)
                .Include(it => it.CarModels)
                .ThenInclude(t => t.CarType);

            if (model != null && model.Id != 0)
            {
                var filtered = brands.Where(it => it.CarModels.Any(cm => cm.CarTypeId == model.Id)).ToList();
                return CreateTableViewModel(EntityMapper.Map(filtered), model.Id);
            }

            var filteredBrands = brands.Where(it => it.CarModels.Any()).ToList();
            return CreateTableViewModel(EntityMapper.Map(filteredBrands));
        }

        private CarBrandTableViewModel CreateTableViewModel(IEnumerable<CarBrandViewModel> brands, long selectedCarTypeId = 0)
        {
            var carTypes = carTypeService.GetAll().OrderBy(it => it.Name).ToList();

            carTypes.Insert(0, new CarTypeViewModel()
            {
                Id = 0,
                Name = "All"
            });

            foreach (var type in carTypes)
            {
                if (type.Id == selectedCarTypeId)
                {
                    type.IsSelected = true;
                }
            }

            var countries = countryService.GetAll();

            return new CarBrandTableViewModel()
            {
                Brands = brands,
                Types = carTypes,
                Countries = countries
            };
        }

        CarBrandViewModel ICarBrandService.GetById(long id)
        {
            var brand = CatalogUow.CarBrands.GetById(id);
            if (brand == null)
            {
                throw new Exception(string.Format("Can't find car brand with id = {0} in DB.", id));
            }

            return EntityMapper.Map(brand);
        }
    }
}