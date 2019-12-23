using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeierSeguros.Infra.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    State = table.Column<string>(type: "varchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Insurer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insurer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Password = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Email = table.Column<string>(type: "varchar(60)", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarWorkshop",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Address = table.Column<string>(type: "varchar(120)", maxLength: 120, nullable: false),
                    CityId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWorkshop", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarWorkshop_City_CityId",
                        column: x => x.CityId,
                        principalTable: "City",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InsurerAssistance",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Phone = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    AssistancePhoneType = table.Column<string>(type: "varchar(1)", maxLength: 1, nullable: false),
                    InsurerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InsurerAssistance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InsurerAssistance_Insurer_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarWorkshopInsurer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CarWorkShopId = table.Column<Guid>(nullable: false),
                    InsurerId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarWorkshopInsurer", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarWorkshopInsurer_CarWorkshop_CarWorkShopId",
                        column: x => x.CarWorkShopId,
                        principalTable: "CarWorkshop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CarWorkshopInsurer_Insurer_InsurerId",
                        column: x => x.InsurerId,
                        principalTable: "Insurer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarWorkshop_CityId",
                table: "CarWorkshop",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWorkshopInsurer_CarWorkShopId",
                table: "CarWorkshopInsurer",
                column: "CarWorkShopId");

            migrationBuilder.CreateIndex(
                name: "IX_CarWorkshopInsurer_InsurerId",
                table: "CarWorkshopInsurer",
                column: "InsurerId");

            migrationBuilder.CreateIndex(
                name: "IX_InsurerAssistance_InsurerId",
                table: "InsurerAssistance",
                column: "InsurerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarWorkshopInsurer");

            migrationBuilder.DropTable(
                name: "InsurerAssistance");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "CarWorkshop");

            migrationBuilder.DropTable(
                name: "Insurer");

            migrationBuilder.DropTable(
                name: "City");
        }
    }
}
