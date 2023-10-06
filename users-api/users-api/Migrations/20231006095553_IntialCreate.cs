using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace users_api.Migrations
{
    /// <inheritdoc />
    public partial class IntialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Age", "Email", "Name", "Role" },
                values: new object[,]
                {
                    { new Guid("0aafc078-c502-4e7f-99d0-a729be33dbad"), 35, "admin@gmail.com", "Admin", 1 },
                    { new Guid("947916c2-6da3-41d8-9b31-ef67601571c0"), 21, "ivan@gmail.com", "Ivan", 2 },
                    { new Guid("b1e5b6ec-c1e7-4ac1-803e-af69ee9eef96"), 20, "vladislav@gmail.com", "Vladislav", 0 },
                    { new Guid("decd1896-bd1c-4f45-8452-33f51d358c1c"), 22, "aleksandr@gmail.com", "Aleksandr", 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
