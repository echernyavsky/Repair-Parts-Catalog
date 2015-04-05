using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace RepairPartsCatalog.Domain.Data.Catalog.Migrations
{
    public partial class initial : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable("CarBrand",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Long(nullable: false)
                    })
                .PrimaryKey("PK_CarBrand", t => t.Id);
            
            migrationBuilder.CreateTable("CarModel",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CarTypeId = c.Long(nullable: false),
                        CarBrandId = c.Long(nullable: false)
                    })
                .PrimaryKey("PK_CarModel", t => t.Id);
            
            migrationBuilder.CreateTable("CarModification",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        CarModelId = c.Long(nullable: false)
                    })
                .PrimaryKey("PK_CarModification", t => t.Id);
            
            migrationBuilder.CreateTable("CarType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String()
                    })
                .PrimaryKey("PK_CarType", t => t.Id);
            
            migrationBuilder.CreateTable("CarVinCode",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        VinCode = c.String(),
                        CarModificationId = c.Long(nullable: false)
                    })
                .PrimaryKey("PK_CarVinCode", t => t.Id);
            
            migrationBuilder.CreateTable("Country",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String()
                    })
                .PrimaryKey("PK_Country", t => t.Id);
            
            migrationBuilder.CreateTable("RepairPart",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        VinCode = c.String(),
                        RepairPartCompanyId = c.Long(nullable: false),
                        RepairPartTypeId = c.Long(nullable: false)
                    })
                .PrimaryKey("PK_RepairPart", t => t.Id);
            
            migrationBuilder.CreateTable("RepairPartCompany",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        CountryId = c.Long(nullable: false)
                    })
                .PrimaryKey("PK_RepairPartCompany", t => t.Id);
            
            migrationBuilder.CreateTable("RepairPartType",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                        ParentRepairPartTypeId = c.Long()
                    })
                .PrimaryKey("PK_RepairPartType", t => t.Id);
            
            migrationBuilder.AddForeignKey(
                "CarBrand",
                "FK_CarBrand_Country_CountryId",
                new[] { "CountryId" },
                "Country",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "CarModel",
                "FK_CarModel_CarType_CarTypeId",
                new[] { "CarTypeId" },
                "CarType",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "CarModel",
                "FK_CarModel_CarBrand_CarBrandId",
                new[] { "CarBrandId" },
                "CarBrand",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "CarModification",
                "FK_CarModification_CarModel_CarModelId",
                new[] { "CarModelId" },
                "CarModel",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "CarVinCode",
                "FK_CarVinCode_CarModification_CarModificationId",
                new[] { "CarModificationId" },
                "CarModification",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "RepairPart",
                "FK_RepairPart_RepairPartCompany_RepairPartCompanyId",
                new[] { "RepairPartCompanyId" },
                "RepairPartCompany",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "RepairPart",
                "FK_RepairPart_RepairPartType_RepairPartTypeId",
                new[] { "RepairPartTypeId" },
                "RepairPartType",
                new[] { "Id" },
                cascadeDelete: false);
            
            migrationBuilder.AddForeignKey(
                "RepairPartCompany",
                "FK_RepairPartCompany_Country_CountryId",
                new[] { "CountryId" },
                "Country",
                new[] { "Id" },
                cascadeDelete: false);
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey("CarModel", "FK_CarModel_CarBrand_CarBrandId");
            
            migrationBuilder.DropForeignKey("CarModification", "FK_CarModification_CarModel_CarModelId");
            
            migrationBuilder.DropForeignKey("CarVinCode", "FK_CarVinCode_CarModification_CarModificationId");
            
            migrationBuilder.DropForeignKey("CarModel", "FK_CarModel_CarType_CarTypeId");
            
            migrationBuilder.DropForeignKey("CarBrand", "FK_CarBrand_Country_CountryId");
            
            migrationBuilder.DropForeignKey("RepairPartCompany", "FK_RepairPartCompany_Country_CountryId");
            
            migrationBuilder.DropForeignKey("RepairPart", "FK_RepairPart_RepairPartCompany_RepairPartCompanyId");
            
            migrationBuilder.DropForeignKey("RepairPart", "FK_RepairPart_RepairPartType_RepairPartTypeId");
            
            migrationBuilder.DropTable("CarBrand");
            
            migrationBuilder.DropTable("CarModel");
            
            migrationBuilder.DropTable("CarModification");
            
            migrationBuilder.DropTable("CarType");
            
            migrationBuilder.DropTable("CarVinCode");
            
            migrationBuilder.DropTable("Country");
            
            migrationBuilder.DropTable("RepairPart");
            
            migrationBuilder.DropTable("RepairPartCompany");
            
            migrationBuilder.DropTable("RepairPartType");
        }
    }
}