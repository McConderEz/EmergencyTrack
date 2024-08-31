using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmergencyTrack.Infrastructure.Mssql.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "city",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    city_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_city", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "procedure",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    procedure_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedure", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "social_statuses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Status_Value = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_social_statuses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "disticts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    district_title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_disticts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_disticts_city_CityId",
                        column: x => x.CityId,
                        principalTable: "city",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sick_persons",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SocialStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    zip_code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    birth_date = table.Column<DateOnly>(type: "date", nullable: false),
                    first_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    patronymic = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    second_name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sick_persons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_sick_persons_social_statuses_SocialStatusId",
                        column: x => x.SocialStatusId,
                        principalTable: "social_statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "emergency_station",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DistrictId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountOfEmployees = table.Column<int>(type: "int", nullable: false),
                    city = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    state = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    street = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    zip_code = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    station_number = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_emergency_station", x => x.Id);
                    table.ForeignKey(
                        name: "FK_emergency_station_disticts_DistrictId",
                        column: x => x.DistrictId,
                        principalTable: "disticts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ambulance_requests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SickPersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmergencyStationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ambulance_requests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ambulance_requests_emergency_station_EmergencyStationId",
                        column: x => x.EmergencyStationId,
                        principalTable: "emergency_station",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ambulance_requests_sick_persons_SickPersonId",
                        column: x => x.SickPersonId,
                        principalTable: "sick_persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "cause_of_recall",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmbulanceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    cause = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cause_of_recall", x => x.Id);
                    table.ForeignKey(
                        name: "FK_cause_of_recall_ambulance_requests_AmbulanceRequestId",
                        column: x => x.AmbulanceRequestId,
                        principalTable: "ambulance_requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "procedure_performeds",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AmbulanceRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_procedure_performeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_procedure_performeds_ambulance_requests_AmbulanceRequestId",
                        column: x => x.AmbulanceRequestId,
                        principalTable: "ambulance_requests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcedureProcedurePerformed",
                columns: table => new
                {
                    ProcedurePerformedsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProceduresId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedureProcedurePerformed", x => new { x.ProcedurePerformedsId, x.ProceduresId });
                    table.ForeignKey(
                        name: "FK_ProcedureProcedurePerformed_procedure_ProceduresId",
                        column: x => x.ProceduresId,
                        principalTable: "procedure",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedureProcedurePerformed_procedure_performeds_ProcedurePerformedsId",
                        column: x => x.ProcedurePerformedsId,
                        principalTable: "procedure_performeds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ambulance_requests_EmergencyStationId",
                table: "ambulance_requests",
                column: "EmergencyStationId");

            migrationBuilder.CreateIndex(
                name: "IX_ambulance_requests_SickPersonId",
                table: "ambulance_requests",
                column: "SickPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_cause_of_recall_AmbulanceRequestId",
                table: "cause_of_recall",
                column: "AmbulanceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_disticts_CityId",
                table: "disticts",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_emergency_station_DistrictId",
                table: "emergency_station",
                column: "DistrictId");

            migrationBuilder.CreateIndex(
                name: "IX_procedure_performeds_AmbulanceRequestId",
                table: "procedure_performeds",
                column: "AmbulanceRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedureProcedurePerformed_ProceduresId",
                table: "ProcedureProcedurePerformed",
                column: "ProceduresId");

            migrationBuilder.CreateIndex(
                name: "IX_sick_persons_SocialStatusId",
                table: "sick_persons",
                column: "SocialStatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cause_of_recall");

            migrationBuilder.DropTable(
                name: "ProcedureProcedurePerformed");

            migrationBuilder.DropTable(
                name: "procedure");

            migrationBuilder.DropTable(
                name: "procedure_performeds");

            migrationBuilder.DropTable(
                name: "ambulance_requests");

            migrationBuilder.DropTable(
                name: "emergency_station");

            migrationBuilder.DropTable(
                name: "sick_persons");

            migrationBuilder.DropTable(
                name: "disticts");

            migrationBuilder.DropTable(
                name: "social_statuses");

            migrationBuilder.DropTable(
                name: "city");
        }
    }
}
