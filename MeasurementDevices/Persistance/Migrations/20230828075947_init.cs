using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountingUnits",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountingUnits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HeadOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeadOrganizations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChildOrganizations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    HeadOrganizationId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChildOrganizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChildOrganizations_HeadOrganizations_HeadOrganizationId",
                        column: x => x.HeadOrganizationId,
                        principalTable: "HeadOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    OwnerOrganizationId = table.Column<int>(nullable: false),
                    OwnerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumers_ChildOrganizations_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "ChildOrganizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DeliveryPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    MaximumPowerOutputInKilowatts = table.Column<decimal>(nullable: false),
                    ConsumerId = table.Column<int>(nullable: false),
                    AccountingInitId = table.Column<int>(nullable: false),
                    AccountingUnitId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryPoints_AccountingUnits_AccountingUnitId",
                        column: x => x.AccountingUnitId,
                        principalTable: "AccountingUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DeliveryPoints_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementPoints",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    ConsumerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementPoints", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurementPoints_Consumers_ConsumerId",
                        column: x => x.ConsumerId,
                        principalTable: "Consumers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrentTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: false),
                    NextVerificationDate = table.Column<DateTime>(nullable: false),
                    TransformationRatio = table.Column<decimal>(nullable: false),
                    MeasurementPointId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrentTransformers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrentTransformers_MeasurementPoints_MeasurementPointId",
                        column: x => x.MeasurementPointId,
                        principalTable: "MeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ElectricityMeters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: false),
                    MeasurementPointId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    NextVerificationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityMeters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ElectricityMeters_MeasurementPoints_MeasurementPointId",
                        column: x => x.MeasurementPointId,
                        principalTable: "MeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MeasurementPeriods",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Start = table.Column<DateTime>(nullable: false),
                    End = table.Column<DateTime>(nullable: false),
                    MeasurementPointId = table.Column<int>(nullable: false),
                    AccountingUnitId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MeasurementPeriods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MeasurementPeriods_AccountingUnits_AccountingUnitId",
                        column: x => x.AccountingUnitId,
                        principalTable: "AccountingUnits",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MeasurementPeriods_MeasurementPoints_MeasurementPointId",
                        column: x => x.MeasurementPointId,
                        principalTable: "MeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VoltageTransformers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Number = table.Column<string>(nullable: false),
                    NextVerificationDate = table.Column<DateTime>(nullable: false),
                    TransformationRatio = table.Column<decimal>(nullable: false),
                    MeasurementPointId = table.Column<int>(nullable: true),
                    Type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VoltageTransformers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VoltageTransformers_MeasurementPoints_MeasurementPointId",
                        column: x => x.MeasurementPointId,
                        principalTable: "MeasurementPoints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChildOrganizations_HeadOrganizationId",
                table: "ChildOrganizations",
                column: "HeadOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_OwnerId",
                table: "Consumers",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_CurrentTransformers_MeasurementPointId",
                table: "CurrentTransformers",
                column: "MeasurementPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPoints_AccountingUnitId",
                table: "DeliveryPoints",
                column: "AccountingUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryPoints_ConsumerId",
                table: "DeliveryPoints",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_ElectricityMeters_MeasurementPointId",
                table: "ElectricityMeters",
                column: "MeasurementPointId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementPeriods_AccountingUnitId",
                table: "MeasurementPeriods",
                column: "AccountingUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementPeriods_MeasurementPointId",
                table: "MeasurementPeriods",
                column: "MeasurementPointId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementPoints_ConsumerId",
                table: "MeasurementPoints",
                column: "ConsumerId");

            migrationBuilder.CreateIndex(
                name: "IX_VoltageTransformers_MeasurementPointId",
                table: "VoltageTransformers",
                column: "MeasurementPointId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrentTransformers");

            migrationBuilder.DropTable(
                name: "DeliveryPoints");

            migrationBuilder.DropTable(
                name: "ElectricityMeters");

            migrationBuilder.DropTable(
                name: "MeasurementPeriods");

            migrationBuilder.DropTable(
                name: "VoltageTransformers");

            migrationBuilder.DropTable(
                name: "AccountingUnits");

            migrationBuilder.DropTable(
                name: "MeasurementPoints");

            migrationBuilder.DropTable(
                name: "Consumers");

            migrationBuilder.DropTable(
                name: "ChildOrganizations");

            migrationBuilder.DropTable(
                name: "HeadOrganizations");
        }
    }
}
