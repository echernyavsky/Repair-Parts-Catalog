using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog.Common;

namespace RepairPartsCatalog.Entities.Catalog
{
    /// <summary>
    /// Car modification entity.
    /// </summary>
    public class CarModification : Entity
    {
        /// <summary>
        /// Reference to car model.
        /// </summary>
        public long CarModelId { get; set; }

        public string Engine { get; set; }

        public string EngineType { get; set; }

        public int EnginePower { get; set; }

        public int EngineHorsePower { get; set; }

        public FuelType EngineFuelType { get; set; }

        public int Year { get; set; }

        /// <summary>
        /// Navigation property to Car Model.
        /// </summary>
        public virtual CarModel Model { get; set; }

        /// <summary>
        /// Navigation properties to available repair parts.
        /// </summary>
        public virtual ICollection<RepairPart> RepairParts { get; set; }

        /// <summary>
        /// Navigation properties to available vin codes.
        /// </summary>
        public virtual ICollection<CarVinCode> VinCodes { get; set; }
    }
}
