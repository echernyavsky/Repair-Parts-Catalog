using System.Collections.Generic;
using System.Linq;
using RepairPartsCatalog.Business.ViewModels;
using RepairPartsCatalog.Entities.Catalog;

namespace Mapper
{
    public class EntityMapper
    {
        public static CountryViewModel Map(Country country)
        {
            return new CountryViewModel()
            {
                Code = country.Code,
                Id = country.Id,
                Name = country.Name
            };
        }

        public static IEnumerable<CountryViewModel> Map(IEnumerable<Country> countries)
        {
            return countries.Select(Map);
        }

        public static CarBrandViewModel Map(CarBrand carBrand)
        {
            return new CarBrandViewModel()
            {
                Id = carBrand.Id,
                Name = carBrand.Name,
                CountryName = carBrand.Country.Name,
                CountryId = carBrand.Country.Id
            };
        }

        public static IEnumerable<CarBrandViewModel> Map(IEnumerable<CarBrand> brands)
        {
            return brands.Select(Map);
        }

        public static CarBrand Map(CarBrandViewModel model)
        {
            return new CarBrand()
            {
                Id = model.Id,
                CountryId = model.CountryId,
                Name = model.Name
            };
        }

        public static IEnumerable<CarBrand> Map(IEnumerable<CarBrandViewModel> models)
        {
            return models.Select(Map);
        }

        public static CarType Map(CarTypeViewModel model)
        {
            return new CarType()
            {
                Id = model.Id,
                Name = model.Name
            };
        }

        public static CarTypeViewModel Map(CarType model, bool isSelected = false)
        {
            return new CarTypeViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                IsSelected = isSelected
            };
        }

        public static CarTypeViewModel Map(CarType model)
        {
            return new CarTypeViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                IsSelected = false
            };
        }

        public static IEnumerable<CarTypeViewModel> Map(IEnumerable<CarType> models)
        {
            return models.Select(Map);
        }
    }
}