using System;

namespace RepairPartsCatalog.Business.ViewModels
{
    public class CarModelViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long CarTypeId { get; set; }

        public long CarBrandId { get; set; }
        
        public string TypeName { get; set; }

        public string BrandName { get; set; }

    }
}