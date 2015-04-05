using System;
using Microsoft.Data.Entity;
using RepairPartsCatalog.Domain.Contracts;
using RepairPartsCatalog.Domain.Contracts.Repositories;
using RepairPartsCatalog.Domain.Data.Catalog.Repositories;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Domain.Data.Catalog
{
    public class CatalogUow : ICatalogUoW, IDisposable
    {
        private readonly DbContext dbContext;

        #region Private Repos
        private IRepository<CarBrand> carBrands;
        private IRepository<CarModel> carModels;
        private IRepository<CarModification> carModifications;
        private IRepository<CarType> carTypes;
        private IRepository<CarVinCode> carVinCodes;
        private IRepository<Country> countries;
        private IRepository<RepairPart> repairParts;
        private IRepository<RepairPartCompany> repairPartCompanies;
        private IRepository<RepairPartType> repairPartTypes;
        #endregion

        IRepository<CarBrand> ICatalogUoW.CarBrands => carBrands ?? (carBrands = new BaseRepository<CarBrand>(dbContext));

        IRepository<CarModel> ICatalogUoW.CarModels => carModels ?? (carModels = new BaseRepository<CarModel>(dbContext));

        IRepository<CarModification> ICatalogUoW.CarModifications => carModifications ?? (carModifications = new BaseRepository<CarModification>(dbContext));

        IRepository<CarType> ICatalogUoW.CarType => carTypes ?? (carTypes = new BaseRepository<CarType>(dbContext));

        IRepository<CarVinCode> ICatalogUoW.CarVinCode => carVinCodes ?? (carVinCodes = new BaseRepository<CarVinCode>(dbContext));

        IRepository<Country> ICatalogUoW.Countries => countries ?? (countries = new BaseRepository<Country>(dbContext));

        IRepository<RepairPart> ICatalogUoW.RepairParts => repairParts ?? (repairParts = new BaseRepository<RepairPart>(dbContext));

        IRepository<RepairPartCompany> ICatalogUoW.RepairPartCompanies => repairPartCompanies ?? (repairPartCompanies = new BaseRepository<RepairPartCompany>(dbContext));

        IRepository<RepairPartType> ICatalogUoW.RepairPartTypes => repairPartTypes ?? (repairPartTypes = new BaseRepository<RepairPartType>(dbContext));
        
        public CatalogUow(RepairPartsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        void ICatalogUoW.Commit()
        {
            dbContext.SaveChanges();
        }

        #region IDisposable
        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose if the appropriate parameter value
        /// </summary>
        /// <param name="disposing">If disposing</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbContext?.Dispose();
            }
        }
        #endregion
    }
}