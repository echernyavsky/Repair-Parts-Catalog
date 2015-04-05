using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog.Common;

namespace RepairPartsCatalog.Entities.Catalog
{
    /// <summary>
    /// Repair part company entity.
    /// </summary>
    public class RepairPartCompany : NamedEntity
    {
        /// <summary>
        /// Country id foreign key.
        /// </summary>
        public long CountryId { get; set; }

        /// <summary>
        /// Company country.
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Navigation property to collection of repair parts.
        /// </summary>
        public virtual ICollection<RepairPart> RepairParts { get; set; }
    }
}
