using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class seedProductToTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Author", "Description", "ISBN", "ListPrice", "ListPrice100", "ListPrice2", "ListPrice50", "Title" },
                values: new object[,]
                {
                    { 1, "Sabahattin Ali", "Güzel bir roman.", "1212454564", 5.0, 4.0, 4.75, 4.25, "Kuyucaklı Yusuf" },
                    { 2, "Sabahattin Ali", "Polisiye Romanı.", "3917854964", 6.0, 5.1500000000000004, 5.7999999999999998, 5.5, "Beyoglu Rapsodisi" },
                    { 3, "İmam Gazali", "Genel kültür kitabı.", "6915445564", 4.75, 4.0, 4.5, 4.25, "Dil Belası" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
