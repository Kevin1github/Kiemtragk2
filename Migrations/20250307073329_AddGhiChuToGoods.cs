using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ktrgk2.Migrations
{
    /// <inheritdoc />
    public partial class AddGhiChuToGoods : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GhiChu",
                table: "Goods",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GhiChu",
                table: "Goods");
        }
    }
}
