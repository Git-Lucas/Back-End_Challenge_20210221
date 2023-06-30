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
                name: "Configuration",
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
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LaunchServiceProvider",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LaunchServiceProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Location",
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
                    table.PrimaryKey("PK_Location", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orbit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Abbrev = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orbit", x => x.Id);
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
                name: "Rocket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    ConfigurationId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rocket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rocket_Configuration_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configuration",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Pad",
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
                    table.PrimaryKey("PK_Pad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pad_Location_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Location",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mission",
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
                    table.PrimaryKey("PK_Mission", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mission_Orbit_OrbitId",
                        column: x => x.OrbitId,
                        principalTable: "Orbit",
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
                        name: "FK_Launchers_LaunchServiceProvider_LaunchServiceProviderId",
                        column: x => x.LaunchServiceProviderId,
                        principalTable: "LaunchServiceProvider",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Launchers_Mission_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Mission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Launchers_Pad_PadId",
                        column: x => x.PadId,
                        principalTable: "Pad",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Launchers_Rocket_RocketId",
                        column: x => x.RocketId,
                        principalTable: "Rocket",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Launchers_Status_StatusLaunchId",
                        column: x => x.StatusLaunchId,
                        principalTable: "Status",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Program",
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
                    table.PrimaryKey("PK_Program", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Program_Launchers_LaunchId",
                        column: x => x.LaunchId,
                        principalTable: "Launchers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Agency",
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
                    table.PrimaryKey("PK_Agency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Agency_Program_ProgramId",
                        column: x => x.ProgramId,
                        principalTable: "Program",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Agency_ProgramId",
                table: "Agency",
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
                name: "IX_Mission_OrbitId",
                table: "Mission",
                column: "OrbitId");

            migrationBuilder.CreateIndex(
                name: "IX_Pad_LocationId",
                table: "Pad",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Program_LaunchId",
                table: "Program",
                column: "LaunchId");

            migrationBuilder.CreateIndex(
                name: "IX_Rocket_ConfigurationId",
                table: "Rocket",
                column: "ConfigurationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agency");

            migrationBuilder.DropTable(
                name: "Program");

            migrationBuilder.DropTable(
                name: "Launchers");

            migrationBuilder.DropTable(
                name: "LaunchServiceProvider");

            migrationBuilder.DropTable(
                name: "Mission");

            migrationBuilder.DropTable(
                name: "Pad");

            migrationBuilder.DropTable(
                name: "Rocket");

            migrationBuilder.DropTable(
                name: "Status");

            migrationBuilder.DropTable(
                name: "Orbit");

            migrationBuilder.DropTable(
                name: "Location");

            migrationBuilder.DropTable(
                name: "Configuration");
        }
    }
}
