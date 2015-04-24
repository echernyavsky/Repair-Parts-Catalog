using System;
using Microsoft.Framework.Runtime;
using RepairPartsCatalog.Domain.Contracts.Repositories;
using RepairPartsCatalog.Entities.Catalog;

namespace RepairPartsCatalog.Domain.Contracts
{
    /// <summary>
    /// Interface to represent Catalog context access.
    /// </summary>
    [AssemblyNeutral]
    public interface ICatalogUoW
    {
        IRepository<CarBrand> CarBrands { get; }

        IRepository<CarModel> CarModels { get; }

        IRepository<CarModification> CarModifications { get; }

        IRepository<CarType> CarTypes { get; }

        IRepository<CarVinCode> CarVinCode { get; }

        IRepository<Country> Countries { get; }

        IRepository<RepairPart> RepairParts { get; }

        IRepository<RepairPartCompany> RepairPartCompanies { get; }

        IRepository<RepairPartType> RepairPartTypes { get; }

        /// <summary>
        /// Save context changes.
        /// </summary>
        void Commit();
    }
}