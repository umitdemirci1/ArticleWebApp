using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Articles",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 2, 42, 57, 51, DateTimeKind.Local).AddTicks(5703));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 2, 42, 57, 51, DateTimeKind.Local).AddTicks(5726));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 2, 42, 57, 51, DateTimeKind.Local).AddTicks(5728));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 2, 42, 57, 51, DateTimeKind.Local).AddTicks(5785));

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedAt",
                value: new DateTime(2024, 9, 17, 2, 42, 57, 51, DateTimeKind.Local).AddTicks(5787));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "5bb95c2d-9be4-4f95-8b69-bbfcd366e5ed", new DateTime(2024, 9, 17, 2, 42, 56, 741, DateTimeKind.Local).AddTicks(4216), "AQAAAAIAAYagAAAAEHru47dRKb6GV6FtjvCvnCK3VucF1nzHezLiGlGG5s7cscZgNN7uvruwHq8UTZO1vQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "b69af298-a9dc-419c-b9fc-6967468fc5ae", new DateTime(2024, 9, 17, 2, 42, 56, 803, DateTimeKind.Local).AddTicks(3238), "AQAAAAIAAYagAAAAEAFZN3RDR6WKED0a83HDcYO2R0/5xsDXi6u0F6mK3j1TkHeAVZKi3v7GkqFel9Ou2Q==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "159c85d4-188d-4d14-8b6c-5accd7eb1bcc", new DateTime(2024, 9, 17, 2, 42, 56, 865, DateTimeKind.Local).AddTicks(4578), "AQAAAAIAAYagAAAAEDsRwzCra35jcBQwqZU21dy0h3OjZ9puLP8SNXexH2E+ktJGMdEgqCaIrUNhrVmk+A==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "15ef1391-edfb-4dda-ad03-e9d7e5921cb7", new DateTime(2024, 9, 17, 2, 42, 56, 927, DateTimeKind.Local).AddTicks(4445), "AQAAAAIAAYagAAAAEBEz3ihOgHWe+pf7/w/idIUDGYRf2GLEprH4cXimQmxtQ1zBtJLYhliJt8w7Ibi7yA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "2a06580f-c35c-44ef-84e0-fb957fe48133", new DateTime(2024, 9, 17, 2, 42, 56, 989, DateTimeKind.Local).AddTicks(5097), "AQAAAAIAAYagAAAAEAWz9bacivYOOphg6oYmBV736u63XsMaMSTl9YiIJg4n+NySr/kYOgvZ72XdS/HDHw==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Articles");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "c725d65b-684f-4e2e-8ad7-9de95675ab07", new DateTime(2024, 9, 11, 21, 10, 42, 810, DateTimeKind.Local).AddTicks(5222), "AQAAAAIAAYagAAAAELBNEmUjt7NDR2r5CA2S0/WMNFejTEOa5Lp5BruVMRezoCgRhlrLfgI2Zq93j3KDyg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "2265b46a-8118-44f3-b2f5-0554b9abb140", new DateTime(2024, 9, 11, 21, 10, 42, 872, DateTimeKind.Local).AddTicks(3399), "AQAAAAIAAYagAAAAEBrslQ2KJCOHddu3NfvHZch2qIPN9JCmkoc8PDVJaNjg+BcqPYj9HIQr6CGZAjjnkA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "1df6d8a3-2dee-4e1d-a915-85e8a302fc5d", new DateTime(2024, 9, 11, 21, 10, 42, 934, DateTimeKind.Local).AddTicks(9349), "AQAAAAIAAYagAAAAEGIUQEW6pqa/n5Aff6+DhvpiLSHLxo+bJFu2jOvFL1H6wSPEDUIZMo+bzwPj1QHpGw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "e4cdfcba-aed3-454f-ae53-d40c5fa2bf63", new DateTime(2024, 9, 11, 21, 10, 42, 996, DateTimeKind.Local).AddTicks(5870), "AQAAAAIAAYagAAAAEH43RX1nEn+vLNFTceZeQ5+484rD3vox03u3fuXDb7UHMGlIy0lzNG5Fgr77SV3K/g==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "9a3707c8-851c-4922-9365-6597d51c86e4", new DateTime(2024, 9, 11, 21, 10, 43, 58, DateTimeKind.Local).AddTicks(3614), "AQAAAAIAAYagAAAAEP1S8QzW6/YHnQ2edRy3ppOdUnJ2IlBCefuM1c2vzBogbFTcnQdA3nOeL4CIUDnBqA==" });
        }
    }
}
