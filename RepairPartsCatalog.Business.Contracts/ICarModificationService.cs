using System;
using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Business.Contracts
{
    public interface ICarModificationService : IBaseService
    {
        void Create(CarModification carModification);

        IEnumerable<CarModification> GetAll();

        CarModification GetById(long id);
    }
}