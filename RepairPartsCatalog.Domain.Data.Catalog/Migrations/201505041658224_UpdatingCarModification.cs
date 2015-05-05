using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace RepairPartsCatalog.Domain.Data.Catalog.Migrations
{
    public partial class UpdatingCarModification : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn("CarModification", "EngineFuelType", c => c.Int(nullable: false));
            
            migrationBuilder.AddColumn("CarModification", "DriveSystem", c => c.Int(nullable: false));
            
            migrationBuilder.AddColumn("CarModification", "NumberOfCylinders", c => c.Int(nullable: false));
            
            migrationBuilder.AddColumn("CarModification", "TransmissionType", c => c.Int(nullable: false));
            
            migrationBuilder.AddColumn("CarModification", "Weight", c => c.Int(nullable: false));
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("CarModification", "DriveSystem");
            
            migrationBuilder.DropColumn("CarModification", "NumberOfCylinders");
            
            migrationBuilder.DropColumn("CarModification", "TransmissionType");
            
            migrationBuilder.DropColumn("CarModification", "Weight");
            
            migrationBuilder.AlterColumn("CarModification", "EngineFuelType", c => c.Int(nullable: false));
        }
    }
}