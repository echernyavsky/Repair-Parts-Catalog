using System;
using System.Collections.Generic;
using System.Linq;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Services
{
    public class CountryService : BaseService, ICountryService
    {
        public CountryService(ICatalogUoW catalogUoW) : base(catalogUoW) {}

        IEnumerable<Country> ICountryService.GetAll()
        {
            var countries = CatalogUow.Countries.All();
            return countries;
        }

        Country ICountryService.GetById(long id)
        {
            var country = CatalogUow.Countries.GetById(id);
            if (country == null)
            {
                throw new Exception(string.Format("Country with id = {0} not found in DB.", id));
            }

            return country;
        }

        Country ICountryService.GetByName(string countryName)
        {
            var country = CatalogUow.Countries.All().SingleOrDefault();
            if (country == null)
            {
                throw new Exception(string.Format("Country with name = \"{0}\" has duplicates in DB.", countryName));
            }

            return country;
        }
    }
}