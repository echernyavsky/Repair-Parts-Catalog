using System;
using System.Collections.Generic;
using RepairPartsCatalog.Business.Contracts;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Services
{
    public class CarModificationService : BaseService, ICarModificationService
    {
        public CarModificationService(ICatalogUoW catalogUow) : base(catalogUow)
        {
            
        }

        void ICarModificationService.Create(CarModification carModification)
        {
            CatalogUow.CarModifications.InsertOrUpdate(carModification);
            CatalogUow.Commit();
        }

        IEnumerable<CarModification> ICarModificationService.GetAll()
        {
            var carModifications = CatalogUow.CarModifications.All();
            return carModifications;
        }

        CarModification ICarModificationService.GetById(long id)
        {
            var carModification = CatalogUow.CarModifications.GetById(id);
            if (carModification == null)
            {
                throw new Exception(string.Format("Car Modification with id = {0} not found in DB.", id));
            }

            return carModification;
        }
    }
}