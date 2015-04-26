namespace RepairPartsCatalog.Business.ViewModels
{
    public class CarBrandViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string CountryName { get; set; }

        public long CountryId { get; set; }
        
        public string ImageUrl { get; set; }
    }
}