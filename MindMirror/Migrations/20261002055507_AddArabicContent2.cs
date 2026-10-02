using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MindMirror.Migrations
{
    /// <inheritdoc />
    public partial class AddArabicContent2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AddressAr",
                table: "Resources",
                type: "TEXT",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DescriptionAr",
                table: "Resources",
                type: "TEXT",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Resources",
                type: "TEXT",
                maxLength: 120,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ContentAr",
                table: "Articles",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SummaryAr",
                table: "Articles",
                type: "TEXT",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TitleAr",
                table: "Articles",
                type: "TEXT",
                maxLength: 150,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddressAr",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "DescriptionAr",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ContentAr",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "SummaryAr",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "TitleAr",
                table: "Articles");
        }
    }
}
