using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RepairPartsCatalog.Domain.Entities;

namespace RepairPartsCatalog.Domain.Data
{
    public class RepairPartsContext : DbContext
    {
        public RepairPartsContext()
        {
            
        }

        public RepairPartsContext(string connectionString) : base(connectionString)
        {
            
        }

        public IDbSet<CarBrand> CarBrands { get; set; }

        public IDbSet<CarModel> CarModels { get; set; }

        public IDbSet<CarModification> CarModifications { get; set; }

        public IDbSet<CarType> CarTypes { get; set; }

        public IDbSet<CarVinCode> CarVinCodes { get; set; }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<RepairPart> RepairParts { get; set; }

        public IDbSet<RepairPartCompany> RepairPartCompanies { get; set; }

        public IDbSet<RepairPartType> RepairPartTypes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
