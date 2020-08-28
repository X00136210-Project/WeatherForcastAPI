using Microsoft.EntityFrameworkCore.Migrations;

namespace WeatherForcastAPI.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forcasts",
                columns: table => new
                {
                    ID = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Condition = table.Column<string>(nullable: true),
                    MaxTemp = table.Column<int>(nullable: false),
                    MinTemp = table.Column<int>(nullable: false),
                    WindDir = table.Column<string>(nullable: true),
                    WindSpeed = table.Column<int>(nullable: false),
                    Outlook = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forcasts", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Forcasts");
        }
    }
}
