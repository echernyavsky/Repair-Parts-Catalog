using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog;
using System.IO;
using RepairPartsCatalog.Business.ViewModels;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface ICountryService : IBaseService
    {
        IEnumerable<CountryViewModel> GetAll();

        Country GetById(long id);

        Country GetByName(string countryName);

        void UploadCsvList(Stream stream);

        CountryTableViewModel GetCountryTable();
    }
}