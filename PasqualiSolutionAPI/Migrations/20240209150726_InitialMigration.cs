using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PasqualiSolution.API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegisterPF",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    birthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    incomeValue = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cpf = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegisterPF", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "RegisterPF",
                columns: new[] { "Id", "birthDate", "cpf", "incomeValue", "name" },
                values: new object[] { 1L, new DateTime(2024, 2, 9, 12, 7, 25, 810, DateTimeKind.Local).AddTicks(5150), "14323412383", 3000m, "Teste PasqualiSolution" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegisterPF");
        }
    }
}
