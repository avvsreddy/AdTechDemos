using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductECatelog.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CatagoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Catagories",
                columns: table => new
                {
                    CatagoryID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Catagories", x => x.CatagoryID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CatagoryID",
                table: "Products",
                column: "CatagoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Catagories_CatagoryID",
                table: "Products",
                column: "CatagoryID",
                principalTable: "Catagories",
                principalColumn: "CatagoryID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Catagories_CatagoryID",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Catagories");

            migrationBuilder.DropIndex(
                name: "IX_Products_CatagoryID",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CatagoryID",
                table: "Products");
        }
    }
}
