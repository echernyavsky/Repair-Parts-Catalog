using RepairPartsCatalog.Domain.Entities.Common;

namespace RepairPartsCatalog.Domain.Entities
{
    /// <summary>
    /// Entity for car vin-code.
    /// </summary>
    public class CarVinCode : Entity
    {
        /// <summary>
        /// Vin-code.
        /// </summary>
        public string VinCode { get; set; }

        /// <summary>
        /// FK to Car Modification.
        /// </summary>
        public long CarModificationId { get; set; }

        /// <summary>
        /// Navigation property to Car Modification.
        /// </summary>
        public virtual CarModification CarModification { get; set; }
    }
}
