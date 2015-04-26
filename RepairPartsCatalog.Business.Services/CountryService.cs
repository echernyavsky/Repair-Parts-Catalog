using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mapper;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;
using RepairPartsCatalog.Business.ViewModels;

namespace RepairPartsCatalog.Business.Services
{
    public class CountryService : BaseService, ICountryService
    {
        private readonly IBaseCsvReader<Country> countryCsvReader;

        public CountryService(
            ICatalogUoW catalogUoW,
            IBaseCsvReader<Country> countryCsvReader
        ) : base(catalogUoW)
        {
            this.countryCsvReader = countryCsvReader;
        }

        IEnumerable<CountryViewModel> ICountryService.GetAll()
        {
            var countries = CatalogUow.Countries.All().OrderBy(it => it.Name);
            return EntityMapper.Map(countries);
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

        void ICountryService.UploadCsvList(Stream stream)
        {
            var countries = countryCsvReader.Read(stream);
            foreach (var country in countries)
            {
                CatalogUow.Countries.InsertOrUpdate(country);
            }

            CatalogUow.Commit();
        }

        CountryTableViewModel ICountryService.GetCountryTable()
        {
            var countries = ((ICountryService)(this)).GetAll();
            var table = new CountryTableViewModel()
            {
                Countries = countries.Select(it => new CountryViewModel()
                {
                    Id = it.Id,
                    Name = it.Name,
                    Code = it.Code
                })
            };

            return table;
        }
    }
}