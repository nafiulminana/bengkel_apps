using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BengkelMotorApp.Migrations
{
    /// <inheritdoc />
    public partial class AddTransactionField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "total_price",
                table: "tb_transaction",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "transaction_date",
                table: "tb_transaction",
                type: "datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "transaction_number",
                table: "tb_transaction",
                type: "varchar(255)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "total_price",
                table: "tb_transaction");

            migrationBuilder.DropColumn(
                name: "transaction_date",
                table: "tb_transaction");

            migrationBuilder.DropColumn(
                name: "transaction_number",
                table: "tb_transaction");
        }
    }
}
