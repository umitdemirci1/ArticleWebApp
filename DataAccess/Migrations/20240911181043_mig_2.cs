using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "Articles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRejected",
                table: "ArticleComments",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                column: "IsRejected",
                value: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                column: "IsRejected",
                value: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                column: "IsRejected",
                value: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                column: "IsRejected",
                value: false);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                column: "IsRejected",
                value: false);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "IsRejected",
                table: "ArticleComments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "296ce301-21aa-4751-90c4-ee13789063a8", new DateTime(2024, 9, 7, 1, 54, 23, 303, DateTimeKind.Local).AddTicks(3248), "AQAAAAIAAYagAAAAEHRQ77o/PvNOL227OZg4SmB29Wfe/2cmFC3VTZd3G5Sgq6hZras4mlFiFZmzfLnHEw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "4f9e8a3d-ccaa-4516-a23e-919aaf5a219e", new DateTime(2024, 9, 7, 1, 54, 23, 365, DateTimeKind.Local).AddTicks(2965), "AQAAAAIAAYagAAAAEMbYVGAYiSdKG33pof51/2/X9EvuZvY7pOzgsNdj6U28zappdAVpymHR+8J0FgtmKQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "7eac635f-31c0-4acd-bada-4a70220d907d", new DateTime(2024, 9, 7, 1, 54, 23, 428, DateTimeKind.Local).AddTicks(5597), "AQAAAAIAAYagAAAAEPae6uKvYsbOBBL3171JwKbhQuRwH4f05tFeqxdsAvYY/q61JKalutl7GzyYirZomw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "2c474488-b820-4753-823c-b4f70d194794", new DateTime(2024, 9, 7, 1, 54, 23, 491, DateTimeKind.Local).AddTicks(1019), "AQAAAAIAAYagAAAAEGuLe3Dfesx/IaHwAL6IY1ntfbrcXkyN44GUmwoIOWLCzABR1Ao5KpLK21TtKEVHXw==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ConcurrencyStamp", "CreatedAt", "PasswordHash" },
                values: new object[] { "b781e1b5-7baf-4327-a25d-ca785dfcc207", new DateTime(2024, 9, 7, 1, 54, 23, 552, DateTimeKind.Local).AddTicks(8938), "AQAAAAIAAYagAAAAEB1VJuglFvw6KPW79S/HZCMsVy5szVA7zaBEIbYvSrkHV2lsHavCTh10uufsEBPQBg==" });
        }
    }
}
