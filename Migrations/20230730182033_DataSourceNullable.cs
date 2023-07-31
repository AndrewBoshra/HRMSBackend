using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMSCore.Migrations
{
    /// <inheritdoc />
    public partial class DataSourceNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_DataSources_DataSourceId",
                table: "Fields");

            migrationBuilder.AlterColumn<int>(
                name: "DataSourceId",
                table: "Fields",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_DataSources_DataSourceId",
                table: "Fields",
                column: "DataSourceId",
                principalTable: "DataSources",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fields_DataSources_DataSourceId",
                table: "Fields");

            migrationBuilder.AlterColumn<int>(
                name: "DataSourceId",
                table: "Fields",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fields_DataSources_DataSourceId",
                table: "Fields",
                column: "DataSourceId",
                principalTable: "DataSources",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
