using System.ComponentModel;

namespace RepairPartsCatalog.Entities.Catalog
{
    public enum DriveSystem
    {
        [Description("2-Wheel Drive; Rear")]
        R = 0,

        [Description("2-Wheel Drive; Front")]
        F = 1, 

        [Description("All Wheel Drive")]
        A = 2,

        [Description("4-Wheel Drive")]
        Four = 3,
    }
}