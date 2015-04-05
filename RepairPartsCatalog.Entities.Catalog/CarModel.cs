using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog.Common;

namespace RepairPartsCatalog.Entities.Catalog
{
    /// <summary>
    /// Car model entity.
    /// </summary>
    public class CarModel : NamedEntity
    {
        /// <summary>
        /// FK to car type.
        /// </summary>
        public long CarTypeId { get; set; }

        /// <summary>
        /// FK to car brand.
        /// </summary>
        public long CarBrandId { get; set; }

        /// <summary>
        /// Navigation property to car type.
        /// </summary>
        public virtual CarType CarType { get; set; }

        /// <summary>
        /// Navigation property to car brand.
        /// </summary>
        public virtual CarBrand CarBrand { get; set; }

        /// <summary>
        /// Navigation property to collection of car modifications.
        /// </summary>
        public virtual ICollection<CarModification> CarModifications { get; set; }
    }
}
