using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HRMSCore.Migrations
{
    /// <inheritdoc />
    public partial class ModfiedRelations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldsRow_FormStep_FormStepId",
                table: "FieldsRow");

            migrationBuilder.DropForeignKey(
                name: "FK_FormField_FieldsRow_FieldsRowId",
                table: "FormField");

            migrationBuilder.DropForeignKey(
                name: "FK_FormStep_Forms_FormId",
                table: "FormStep");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldsRow_FormStep_FormStepId",
                table: "FieldsRow",
                column: "FormStepId",
                principalTable: "FormStep",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormField_FieldsRow_FieldsRowId",
                table: "FormField",
                column: "FieldsRowId",
                principalTable: "FieldsRow",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FormStep_Forms_FormId",
                table: "FormStep",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FieldsRow_FormStep_FormStepId",
                table: "FieldsRow");

            migrationBuilder.DropForeignKey(
                name: "FK_FormField_FieldsRow_FieldsRowId",
                table: "FormField");

            migrationBuilder.DropForeignKey(
                name: "FK_FormStep_Forms_FormId",
                table: "FormStep");

            migrationBuilder.AddForeignKey(
                name: "FK_FieldsRow_FormStep_FormStepId",
                table: "FieldsRow",
                column: "FormStepId",
                principalTable: "FormStep",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormField_FieldsRow_FieldsRowId",
                table: "FormField",
                column: "FieldsRowId",
                principalTable: "FieldsRow",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FormStep_Forms_FormId",
                table: "FormStep",
                column: "FormId",
                principalTable: "Forms",
                principalColumn: "Id");
        }
    }
}
