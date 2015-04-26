using System;
using System.Collections.Generic;

namespace RepairPartsCatalog.Business.ViewModels
{
    public class CarBrandTableViewModel
    {
        public IEnumerable<CarBrandViewModel> Brands { get; set; }

        public IEnumerable<CarTypeViewModel> Types { get; set; }

        public IEnumerable<CountryViewModel> Countries { get; set; }
    }
}