using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace arz.eda.Migrations
{
    public partial class EditTimeWorkRestaurant : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeWork",
                table: "Restaurants");

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeWorkEnd",
                table: "Restaurants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "TimeWorkStart",
                table: "Restaurants",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeWorkEnd",
                table: "Restaurants");

            migrationBuilder.DropColumn(
                name: "TimeWorkStart",
                table: "Restaurants");

            migrationBuilder.AddColumn<string>(
                name: "TimeWork",
                table: "Restaurants",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
