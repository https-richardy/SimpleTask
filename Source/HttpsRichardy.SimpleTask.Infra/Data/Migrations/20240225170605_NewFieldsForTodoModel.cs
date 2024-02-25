using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HttpsRichardy.SimpleTask.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class NewFieldsForTodoModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "ToDos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DueDate",
                table: "ToDos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Priority",
                table: "ToDos",
                type: "INTEGER",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "DueDate",
                table: "ToDos");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "ToDos");
        }
    }
}
