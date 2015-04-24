using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace RepairPartsCatalog.Domain.Data.Catalog.Migrations
{
    public partial class UpdatingCarModificationTable : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn("CarModification", "Engine", c => c.String());
            
            migrationBuilder.AddColumn("CarModification", "EngineFuelType", c => c.Int(nullable: false));
            
            migrationBuilder.AddColumn("CarModification", "EngineHorsePower", c => c.Int(nullable: false));
            
            migrationBuilder.AddColumn("CarModification", "EnginePower", c => c.Int(nullable: false));
            
            migrationBuilder.AddColumn("CarModification", "EngineType", c => c.String());
            
            migrationBuilder.AddColumn("CarModification", "Year", c => c.Int(nullable: false));
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("CarModification", "Engine");
            
            migrationBuilder.DropColumn("CarModification", "EngineFuelType");
            
            migrationBuilder.DropColumn("CarModification", "EngineHorsePower");
            
            migrationBuilder.DropColumn("CarModification", "EnginePower");
            
            migrationBuilder.DropColumn("CarModification", "EngineType");
            
            migrationBuilder.DropColumn("CarModification", "Year");
        }
    }
}