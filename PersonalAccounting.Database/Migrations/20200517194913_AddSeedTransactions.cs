using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PersonalAccounting.Database.Migrations
{
    public partial class AddSeedTransactions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "BudgetId", "CategoryId", "CreatedAt", "CreatedBy", "Date", "Note", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { 1L, 15f, 1L, 1L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, new DateTime(2020, 5, 15, 14, 30, 0, 0, DateTimeKind.Utc), "Some note", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L },
                    { 2L, 47f, 1L, 2L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, new DateTime(2020, 5, 15, 14, 30, 0, 0, DateTimeKind.Utc), "Some note", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L },
                    { 3L, 33f, 1L, 3L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, new DateTime(2020, 5, 15, 14, 30, 0, 0, DateTimeKind.Utc), "Some note", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L },
                    { 4L, 27f, 1L, 4L, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L, new DateTime(2020, 5, 15, 14, 30, 0, 0, DateTimeKind.Utc), "Some note", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0L }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 4L);
        }
    }
}
