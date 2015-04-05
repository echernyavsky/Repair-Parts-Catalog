using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Relational.Migrations.Infrastructure;
using RepairPartsCatalog.Domain.Data.Catalog;
using System;

namespace RepairPartsCatalog.Domain.Data.Catalog.Migrations
{
    [ContextType(typeof(RepairPartsCatalog.Domain.Data.Catalog.RepairPartsContext))]
    public partial class initial : IMigrationMetadata
    {
        string IMigrationMetadata.MigrationId
        {
            get
            {
                return "201504051905293_initial";
            }
        }
        
        string IMigrationMetadata.ProductVersion
        {
            get
            {
                return "7.0.0-beta3-12166";
            }
        }
        
        IModel IMigrationMetadata.TargetModel
        {
            get
            {
                var builder = new BasicModelBuilder();
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.CarBrand", b =>
                    {
                        b.Property<long>("CountryId");
                        b.Property<long>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Key("Id");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.CarModel", b =>
                    {
                        b.Property<long>("CarBrandId");
                        b.Property<long>("CarTypeId");
                        b.Property<long>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Key("Id");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.CarModification", b =>
                    {
                        b.Property<long>("CarModelId");
                        b.Property<long>("Id")
                            .GenerateValueOnAdd();
                        b.Key("Id");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.CarType", b =>
                    {
                        b.Property<long>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Key("Id");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.CarVinCode", b =>
                    {
                        b.Property<long>("CarModificationId");
                        b.Property<long>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("VinCode");
                        b.Key("Id");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.Country", b =>
                    {
                        b.Property<long>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Key("Id");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.RepairPart", b =>
                    {
                        b.Property<long>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Property<long>("RepairPartCompanyId");
                        b.Property<long>("RepairPartTypeId");
                        b.Property<string>("VinCode");
                        b.Key("Id");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.RepairPartCompany", b =>
                    {
                        b.Property<long>("CountryId");
                        b.Property<long>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Key("Id");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.RepairPartType", b =>
                    {
                        b.Property<long>("Id")
                            .GenerateValueOnAdd();
                        b.Property<string>("Name");
                        b.Property<long?>("ParentRepairPartTypeId");
                        b.Key("Id");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.CarBrand", b =>
                    {
                        b.ForeignKey("RepairPartsCatalog.Entities.Catalog.Country", "CountryId");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.CarModel", b =>
                    {
                        b.ForeignKey("RepairPartsCatalog.Entities.Catalog.CarType", "CarTypeId");
                        b.ForeignKey("RepairPartsCatalog.Entities.Catalog.CarBrand", "CarBrandId");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.CarModification", b =>
                    {
                        b.ForeignKey("RepairPartsCatalog.Entities.Catalog.CarModel", "CarModelId");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.CarVinCode", b =>
                    {
                        b.ForeignKey("RepairPartsCatalog.Entities.Catalog.CarModification", "CarModificationId");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.RepairPart", b =>
                    {
                        b.ForeignKey("RepairPartsCatalog.Entities.Catalog.RepairPartCompany", "RepairPartCompanyId");
                        b.ForeignKey("RepairPartsCatalog.Entities.Catalog.RepairPartType", "RepairPartTypeId");
                    });
                
                builder.Entity("RepairPartsCatalog.Entities.Catalog.RepairPartCompany", b =>
                    {
                        b.ForeignKey("RepairPartsCatalog.Entities.Catalog.Country", "CountryId");
                    });
                
                return builder.Model;
            }
        }
    }
}