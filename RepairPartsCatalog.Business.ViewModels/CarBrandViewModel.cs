namespace RepairPartsCatalog.Business.ViewModels
{
    public class CarBrandViewModel
    {
        public long Id { get; set; }

        /// <summary>
        /// Object name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// FK to related country.
        /// </summary>
        public long CountryId { get; set; }

        public CountryViewModel Country { get; set; }
    }
}