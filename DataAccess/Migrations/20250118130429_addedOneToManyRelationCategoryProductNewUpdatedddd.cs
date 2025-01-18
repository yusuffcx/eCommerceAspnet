using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addedOneToManyRelationCategoryProductNewUpdatedddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "CategoryID", "Description", "ISBN", "ListPrice", "ListPrice100", "ListPrice2", "ListPrice50", "Title" },
                values: new object[,]
                {
                    { 1, "Sabahattin Ali", 3, "Güzel bir roman.", "1212454564", 5.0, 4.0, 4.75, 4.25, "Kuyucaklı Yusuf" },
                    { 2, "Sabahattin Ali", 3, "Polisiye Romanı.", "3917854964", 6.0, 5.1500000000000004, 5.7999999999999998, 5.5, "Beyoglu Rapsodisi" },
                    { 3, "İmam Gazali", 2, "Genel kültür kitabı.", "6915445564", 4.75, 4.0, 4.5, 4.25, "Dil Belası" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryID",
                table: "Products",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categories_CategoryID",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CategoryID",
                table: "Products");

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Products");
        }
    }
}
