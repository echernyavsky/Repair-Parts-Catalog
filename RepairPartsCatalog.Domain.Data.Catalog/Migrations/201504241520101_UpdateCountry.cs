using Microsoft.Data.Entity.Relational.Migrations;
using Microsoft.Data.Entity.Relational.Migrations.Builders;
using Microsoft.Data.Entity.Relational.Migrations.MigrationsModel;
using System;

namespace RepairPartsCatalog.Domain.Data.Catalog.Migrations
{
    public partial class UpdateCountry : Migration
    {
        public override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn("CarModification", "EngineFuelType", c => c.Int(nullable: false));
            
            migrationBuilder.AddColumn("Country", "Code", c => c.String());
        }
        
        public override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Country", "Code");
            
            migrationBuilder.AlterColumn("CarModification", "EngineFuelType", c => c.Int(nullable: false));
        }
    }
}