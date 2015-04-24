using System;
using System.Collections;
using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog;
using RepairPartsCatalog.Business.ViewModels;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface ICarBrandService
    {
        IEnumerable<CarBrandViewModel> GetAll();

        CarBrandViewModel GetById(long id);

        void Create(CarBrandViewModel carBrand);
    }
}