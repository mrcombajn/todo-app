using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TodoApi.Migrations
{
    /// <inheritdoc />
    public partial class TodoDto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Todos");

            migrationBuilder.AddColumn<TimeOnly>(
                name: "DueTime",
                table: "Todos",
                type: "time without time zone",
                nullable: false,
                defaultValue: new TimeOnly(0, 0, 0));

            migrationBuilder.AddColumn<bool>(
                name: "IsDone",
                table: "Todos",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DueTime",
                table: "Todos");

            migrationBuilder.DropColumn(
                name: "IsDone",
                table: "Todos");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Todos",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "State",
                table: "Todos",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
