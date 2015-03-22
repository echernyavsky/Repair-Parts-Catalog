using System.Collections;
using System.Collections.Generic;
using RepairPartsCatalog.Domain.Entities.Common;

namespace RepairPartsCatalog.Domain.Entities
{
    /// <summary>
    /// Repair part entity.
    /// </summary>
    public class RepairPart : NamedEntity
    {
        /// <summary>
        /// Repair part VIN code
        /// </summary>
        public string VinCode { get; set; }

        /// <summary>
        /// Repair part type FK.
        /// </summary>
        public long RepairPartTypeId { get; set; }

        /// <summary>
        /// Repair part company FK.
        /// </summary>
        public long RepairPartCompanyId { get; set; }

        /// <summary>
        /// Navigation property to repair part type.
        /// </summary>
        public virtual RepairPartType RepairPartType { get; set; }

        /// <summary>
        /// Navigation property to repair part company.
        /// </summary>
        public virtual RepairPartCompany RepairPartCompany { get; set; }

        /// <summary>
        /// Navigation property to car modification for which this part is available.
        /// </summary>
        public virtual ICollection<CarModification> CarModifications { get; set; }
    }
}
