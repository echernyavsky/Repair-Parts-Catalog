using System;
using System.Collections;
using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface ICountryService : IBaseService
    {
        IEnumerable<Country> GetAll();

        Country GetById(long id);

        Country GetByName(string countryName);
    }
}