﻿using System.Collections.Generic;
using RepairPartsCatalog.Entities.Catalog.Common;

namespace RepairPartsCatalog.Entities.Catalog
{
    /// <summary>
    /// Car brand entity.
    /// </summary>
    public class CarBrand : NamedEntity
    {
        /// <summary>
        /// FK to related country.
        /// </summary>
        public long CountryId { get; set; }

        /// <summary>
        /// Navigation property to related country.
        /// </summary>
        public virtual Country Country { get; set; }

        /// <summary>
        /// Navigation property to available car models.
        /// </summary>
        public virtual ICollection<CarModel> CarModels { get; set; }
    }
}