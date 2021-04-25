using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DMS.Persistence.Migrations
{
    public partial class mig04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atr1",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Atr2",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Atr3",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Atr4",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Atr5",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Atr6",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Atr7",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "UOM",
                table: "Item");

            migrationBuilder.AddColumn<Guid>(
                name: "Image",
                table: "Item",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "Item",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "Atr1",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atr2",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atr3",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atr4",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atr5",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atr6",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atr7",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UOM",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
