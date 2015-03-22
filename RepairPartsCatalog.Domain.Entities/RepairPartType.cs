﻿using System.Collections.Generic;
using RepairPartsCatalog.Domain.Entities.Common;

namespace RepairPartsCatalog.Domain.Entities
{
    /// <summary>
    /// Repair part type entity.
    /// </summary>
    public class RepairPartType : NamedEntity
    {
        /// <summary>
        /// Reference to parent node.
        /// </summary>
        public long? ParentRepairPartTypeId { get; set; }

        /// <summary>
        /// Navigation property to parent node.
        /// </summary>
        public virtual RepairPartType ParentRepairPartType { get; set; }

        /// <summary>
        /// Navigation property to collection of repair parts.
        /// </summary>
        public virtual ICollection<RepairPart> RepairParts { get; set; }
    }
}
