namespace RepairPartsCatalog.Entities.Catalog.Common
{
    /// <summary>
    /// Base class for entities with Name property
    /// </summary>
    public class NamedEntity : Entity
    {
        /// <summary>
        /// Object name.
        /// </summary>
        public string Name { get; set; }
    }
}
