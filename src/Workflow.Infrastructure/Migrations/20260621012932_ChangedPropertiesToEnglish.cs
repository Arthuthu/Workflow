using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Workflow.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangedPropertiesToEnglish : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Titulo",
                table: "Work",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Descricao",
                table: "Work",
                newName: "Description");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Work",
                newName: "Titulo");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Work",
                newName: "Descricao");
        }
    }
}
