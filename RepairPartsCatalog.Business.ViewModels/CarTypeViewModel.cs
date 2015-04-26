using System;

namespace RepairPartsCatalog.Business.ViewModels
{
    public class CarTypeViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public bool IsSelected { get; set; }
    }
}