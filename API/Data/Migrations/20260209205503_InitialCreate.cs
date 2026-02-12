using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder) //the up method is what's going to happen when we update our database
        {
            migrationBuilder.CreateTable( //creates a table called users with three columns
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "TEXT", nullable: false),
                    DisplayName = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id); //uses the ID property as the primary key for that table
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder) //drops the table if we roll back this migration or remove this migration
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
