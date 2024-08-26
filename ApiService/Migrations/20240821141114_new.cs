using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiService.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "outputs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    next_output_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    previous_output_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_outputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_outputs_outputs_next_output_id",
                        column: x => x.next_output_id,
                        principalTable: "outputs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_outputs_outputs_previous_output_id",
                        column: x => x.previous_output_id,
                        principalTable: "outputs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "choices",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    value = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    previous_output_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    next_output_id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    time = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_choices", x => x.id);
                    table.ForeignKey(
                        name: "FK_choices_outputs_next_output_id",
                        column: x => x.next_output_id,
                        principalTable: "outputs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_choices_outputs_previous_output_id",
                        column: x => x.previous_output_id,
                        principalTable: "outputs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_choices_next_output_id",
                table: "choices",
                column: "next_output_id",
                unique: true,
                filter: "[next_output_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_choices_previous_output_id",
                table: "choices",
                column: "previous_output_id");

            migrationBuilder.CreateIndex(
                name: "IX_outputs_next_output_id",
                table: "outputs",
                column: "next_output_id",
                unique: true,
                filter: "[next_output_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_outputs_previous_output_id",
                table: "outputs",
                column: "previous_output_id",
                unique: true,
                filter: "[previous_output_id] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "choices");

            migrationBuilder.DropTable(
                name: "outputs");
        }
    }
}
