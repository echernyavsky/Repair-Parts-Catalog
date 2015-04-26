using System;
using System.Collections;
using System.Collections.Generic;
using RepairPartsCatalog.Business.ViewModels;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface ICarBrandService
    {
        IEnumerable<CarBrandViewModel> GetAll();

        CarBrandViewModel GetById(long id);

        CarBrandViewModel Create(CarBrandViewModel carBrand);

        CarBrandTableViewModel GetCarBrandsTable(CarTypeViewModel model = null);
    }
}