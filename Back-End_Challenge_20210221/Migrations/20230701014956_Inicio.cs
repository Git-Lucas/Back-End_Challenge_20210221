using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Back_End_Challenge_20210221.Migrations
{
    /// <inheritdoc />
    public partial class Inicio : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Configurations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LaunchLibraryId = table.Column<long>(type: "bigint", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Family = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Variant = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configurations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaunchServiceProviders",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaunchServiceProviders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CountryCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLaunchCount = table.Column<long>(type: "bigint", nullable: false),
                    TotalLandingCount = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orbits",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbrev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orbits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Status",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Status", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rockets",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ConfigurationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rockets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rockets_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pads",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AgencyId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InfoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WikiUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MapUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Latitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Longitude = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LocationId = table.Column<long>(type: "bigint", nullable: true),
                    MapImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalLaunchCount = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pads", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pads_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    LaunchLibraryId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaunchDesignator = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrbitId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Missions_Orbits_OrbitId",
                        column: x => x.OrbitId,
                        principalTable: "Orbits",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Launchers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaunchLibraryId = table.Column<long>(type: "bigint", nullable: true),
                    Slug = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StatusLaunchId = table.Column<long>(type: "bigint", nullable: true),
                    Net = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WindowEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WindowStart = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Inhold = table.Column<bool>(type: "bit", nullable: false),
                    Tbdtime = table.Column<bool>(type: "bit", nullable: false),
                    Tbddate = table.Column<bool>(type: "bit", nullable: false),
                    Probability = table.Column<long>(type: "bigint", nullable: true),
                    Holdreason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Failreason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hashtag = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaunchServiceProviderId = table.Column<long>(type: "bigint", nullable: true),
                    RocketId = table.Column<long>(type: "bigint", nullable: true),
                    MissionId = table.Column<long>(type: "bigint", nullable: true),
                    PadId = table.Column<long>(type: "bigint", nullable: true),
                    WebcastLive = table.Column<bool>(type: "bit", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Infographic = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imported_T = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Launchers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Launchers_LaunchServiceProviders_LaunchServiceProviderId",
                        column: x => x.LaunchServiceProviderId,
                        principalTable: "LaunchServiceProviders",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Launchers_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Launchers_Pads_PadId",
                        column: x => x.PadId,
                        principalTable: "Pads",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Launchers_Rockets_RocketId",
                        column: x => x.RocketId,
                        principalTable: "Rockets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Launchers_Status_StatusLaunchId",
                        column: x => x.StatusLaunchId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Programs",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EndDate = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    InfoUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WikiUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LaunchId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Programs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Programs_Launchers_LaunchId",
                        column: x => x.LaunchId,
                        principalTable: "Launchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agencies",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProgramId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agencies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agencies_Programs_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Programs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agencies_ProgramId",
                table: "Agencies",
                column: "ProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_Launchers_LaunchServiceProviderId",
                table: "Launchers",
                column: "LaunchServiceProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Launchers_MissionId",
                table: "Launchers",
                column: "MissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Launchers_PadId",
                table: "Launchers",
                column: "PadId");

            migrationBuilder.CreateIndex(
                name: "IX_Launchers_RocketId",
                table: "Launchers",
                column: "RocketId");

            migrationBuilder.CreateIndex(
                name: "IX_Launchers_StatusLaunchId",
                table: "Launchers",
                column: "StatusLaunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_OrbitId",
                table: "Missions",
                column: "OrbitId");

            migrationBuilder.CreateIndex(
                name: "IX_Pads_LocationId",
                table: "Pads",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Programs_LaunchId",
                table: "Programs",
                column: "LaunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Rockets_ConfigurationId",
                table: "Rockets",
                column: "ConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agencies");

            migrationBuilder.DropTable(
                name: "Programs");

            migrationBuilder.DropTable(
                name: "Launchers");

            migrationBuilder.DropTable(
                name: "LaunchServiceProviders");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Pads");

            migrationBuilder.DropTable(
                name: "Rockets");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Orbits");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Configurations");
        }
    }
}
