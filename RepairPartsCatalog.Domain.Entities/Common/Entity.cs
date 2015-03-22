using System.ComponentModel.DataAnnotations;

namespace RepairPartsCatalog.Domain.Entities.Common
{
    /// <summary>
    /// Base class for all entities.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Primary key for all DB entities.
        /// </summary>
        [Key]
        public long Id { get; set; }
    }
}