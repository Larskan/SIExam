using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TitleService.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Titles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Tier = table.Column<int>(type: "int", nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TierAdvancementRequirements = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VitalityGain = table.Column<int>(type: "int", nullable: false),
                    EnduranceGain = table.Column<int>(type: "int", nullable: false),
                    StrengthGain = table.Column<int>(type: "int", nullable: false),
                    IntelligenceGain = table.Column<int>(type: "int", nullable: false),
                    MentalityGain = table.Column<int>(type: "int", nullable: false),
                    DexterityGain = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Titles", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Titles");
        }
    }
}
