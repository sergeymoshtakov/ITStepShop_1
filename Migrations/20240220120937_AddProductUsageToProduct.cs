using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace ITStepShop.Migrations
{
    /// <inheritdoc />
    public partial class AddProductUsageToProduct : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductUsageId",
                table: "Product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ProductUsage",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductUsage", x => x.Id);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductUsageId",
                table: "Product",
                column: "ProductUsageId");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_ProductUsage_ProductUsageId",
                table: "Product",
                column: "ProductUsageId",
                principalTable: "ProductUsage",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_ProductUsage_ProductUsageId",
                table: "Product");

            migrationBuilder.DropTable(
                name: "ProductUsage");

            migrationBuilder.DropIndex(
                name: "IX_Product_ProductUsageId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ProductUsageId",
                table: "Product");
        }
    }
}
