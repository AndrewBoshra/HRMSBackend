using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HRMSCore.Migrations
{
    /// <inheritdoc />
    public partial class AddForms : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormStep",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    FormId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormStep_Forms_FormId",
                        column: x => x.FormId,
                        principalTable: "Forms",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FieldsRow",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    FormStepId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FieldsRow", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FieldsRow_FormStep_FormStepId",
                        column: x => x.FormStepId,
                        principalTable: "FormStep",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FormField",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    FieldId = table.Column<int>(type: "integer", nullable: false),
                    FieldsRowId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormField", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FormField_FieldsRow_FieldsRowId",
                        column: x => x.FieldsRowId,
                        principalTable: "FieldsRow",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FormField_Fields_FieldId",
                        column: x => x.FieldId,
                        principalTable: "Fields",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FieldsRow_FormStepId",
                table: "FieldsRow",
                column: "FormStepId");

            migrationBuilder.CreateIndex(
                name: "IX_FormField_FieldId",
                table: "FormField",
                column: "FieldId");

            migrationBuilder.CreateIndex(
                name: "IX_FormField_FieldsRowId",
                table: "FormField",
                column: "FieldsRowId");

            migrationBuilder.CreateIndex(
                name: "IX_FormStep_FormId",
                table: "FormStep",
                column: "FormId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FormField");

            migrationBuilder.DropTable(
                name: "FieldsRow");

            migrationBuilder.DropTable(
                name: "FormStep");

            migrationBuilder.DropTable(
                name: "Forms");
        }
    }
}
