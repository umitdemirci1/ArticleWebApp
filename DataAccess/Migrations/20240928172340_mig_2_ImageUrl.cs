using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class mig_2_ImageUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("d54d970d-dff1-49b4-bd4f-438f0b3a8bec"), new Guid("23cd5436-94e4-4428-bc70-d852d40e135d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fc815bfa-4553-4fa5-a122-d87dd80d6fda"), new Guid("a4523db6-ab98-41ed-a598-11419ad168e3") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("64ec8363-9d54-498a-b3da-3aba1925b8e4"), new Guid("adb10406-74a5-43d0-8dc4-7c7601a2be81") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fc815bfa-4553-4fa5-a122-d87dd80d6fda"), new Guid("e0d55b4b-b6b5-49ee-bbd7-95ae242c3391") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("fc815bfa-4553-4fa5-a122-d87dd80d6fda"), new Guid("ed33ce45-691f-4fb9-b363-bf030e3bbba1") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("64ec8363-9d54-498a-b3da-3aba1925b8e4"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("d54d970d-dff1-49b4-bd4f-438f0b3a8bec"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("fc815bfa-4553-4fa5-a122-d87dd80d6fda"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("23cd5436-94e4-4428-bc70-d852d40e135d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4523db6-ab98-41ed-a598-11419ad168e3"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("adb10406-74a5-43d0-8dc4-7c7601a2be81"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e0d55b4b-b6b5-49ee-bbd7-95ae242c3391"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("ed33ce45-691f-4fb9-b363-bf030e3bbba1"));

            migrationBuilder.DropColumn(
                name: "Data",
                table: "ArticleImages");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "ArticleImages",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("d0a95d9a-c2e8-41c1-ab08-188e3c15f169"), new DateTime(2024, 9, 28, 20, 23, 39, 934, DateTimeKind.Local).AddTicks(3128) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("8c4dd648-d3b4-4573-b7d1-add1c3064f13"), new DateTime(2024, 9, 28, 20, 23, 39, 934, DateTimeKind.Local).AddTicks(3151) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("e6c8382d-ab23-4d39-8bdf-5026d8c4cf3d"), new DateTime(2024, 9, 28, 20, 23, 39, 934, DateTimeKind.Local).AddTicks(3154) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("be663005-f2c3-4ac7-9287-921c027d9388"), new DateTime(2024, 9, 28, 20, 23, 39, 934, DateTimeKind.Local).AddTicks(3162) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("eaeb06ad-6dbd-491e-9aa6-60e339c20bde"), new DateTime(2024, 9, 28, 20, 23, 39, 934, DateTimeKind.Local).AddTicks(3164) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("d0a95d9a-c2e8-41c1-ab08-188e3c15f169"), new DateTime(2024, 9, 28, 20, 23, 39, 934, DateTimeKind.Local).AddTicks(3167) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("8c4dd648-d3b4-4573-b7d1-add1c3064f13"), new DateTime(2024, 9, 28, 20, 23, 39, 934, DateTimeKind.Local).AddTicks(3170) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("e6c8382d-ab23-4d39-8bdf-5026d8c4cf3d"), new DateTime(2024, 9, 28, 20, 23, 39, 934, DateTimeKind.Local).AddTicks(3172) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0a17cce9-7172-4fc5-bdc1-0454b0d22f48"), null, "Admin", "ADMIN" },
                    { new Guid("81882136-1a64-496d-b78b-420ee68fcf92"), null, "User", "USER" },
                    { new Guid("f36ed4d1-8fc7-4cf2-8e4b-9db05c83e306"), null, "Author", "AUTHOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("8c4dd648-d3b4-4573-b7d1-add1c3064f13"), 0, "8bdca056-dc57-4b2f-bb7b-a900f2214ea9", new DateTime(2024, 9, 28, 20, 23, 39, 683, DateTimeKind.Local).AddTicks(4580), "user2@example.com", true, "Jane", false, "Doe", false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEADSh9K07lMadAmZHefRzCCsCXbytTK0WI5t+a1aq8bAV3dPnGv9222c0kDCHb5I0A==", null, false, "", false, "user2" },
                    { new Guid("be663005-f2c3-4ac7-9287-921c027d9388"), 0, "d8d0b506-6f2c-4ca1-9aff-5ea2e1224c3f", new DateTime(2024, 9, 28, 20, 23, 39, 808, DateTimeKind.Local).AddTicks(3893), "user4@example.com", true, "Hans", false, "Doe", false, null, "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEMK364y1O23OYGshO7HJk/MUaOD4VEr1i+wDAg2nh1TFSxbTF77a06lfmq8pJIbMMQ==", null, false, "", false, "user4" },
                    { new Guid("d0a95d9a-c2e8-41c1-ab08-188e3c15f169"), 0, "ba89eb05-ce72-4b04-b8b9-df5eca1c8130", new DateTime(2024, 9, 28, 20, 23, 39, 621, DateTimeKind.Local).AddTicks(5606), "user1@example.com", true, "John", false, "Doe", false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEPLNr0eLIqaReF6B01ajXDaUTSL7B68KDN1gFREiI8C9Y8ylQVVtITxzmNLWT+8+zw==", null, false, "", false, "user1" },
                    { new Guid("e6c8382d-ab23-4d39-8bdf-5026d8c4cf3d"), 0, "4fb1576d-57f2-43ba-bd46-59c34e7a6007", new DateTime(2024, 9, 28, 20, 23, 39, 745, DateTimeKind.Local).AddTicks(1250), "user3@example.com", true, "Mark", false, "Doe", false, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEIOLLHBnISUIXdhDhL4ysrll+KN7DtIm8c1eM4JOUq7Z7kpK7qTv8r7snyDrEoDrsw==", null, false, "", false, "user3" },
                    { new Guid("eaeb06ad-6dbd-491e-9aa6-60e339c20bde"), 0, "304756f4-d221-45bb-9d47-4ff0aa3566c9", new DateTime(2024, 9, 28, 20, 23, 39, 871, DateTimeKind.Local).AddTicks(5508), "user5@example.com", true, "Marry", false, "Doe", false, null, "USER5@EXAMPLE.COM", "USER5", "AQAAAAIAAYagAAAAED6mRf6rjsHT7uqmo2yjDFSemFw0ux6jDDlCyf1exS0dpvUr0J+uU1pwWrGPGrbZ0Q==", null, false, "", false, "user5" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("f36ed4d1-8fc7-4cf2-8e4b-9db05c83e306"), new Guid("8c4dd648-d3b4-4573-b7d1-add1c3064f13") },
                    { new Guid("81882136-1a64-496d-b78b-420ee68fcf92"), new Guid("be663005-f2c3-4ac7-9287-921c027d9388") },
                    { new Guid("0a17cce9-7172-4fc5-bdc1-0454b0d22f48"), new Guid("d0a95d9a-c2e8-41c1-ab08-188e3c15f169") },
                    { new Guid("81882136-1a64-496d-b78b-420ee68fcf92"), new Guid("e6c8382d-ab23-4d39-8bdf-5026d8c4cf3d") },
                    { new Guid("81882136-1a64-496d-b78b-420ee68fcf92"), new Guid("eaeb06ad-6dbd-491e-9aa6-60e339c20bde") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f36ed4d1-8fc7-4cf2-8e4b-9db05c83e306"), new Guid("8c4dd648-d3b4-4573-b7d1-add1c3064f13") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81882136-1a64-496d-b78b-420ee68fcf92"), new Guid("be663005-f2c3-4ac7-9287-921c027d9388") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("0a17cce9-7172-4fc5-bdc1-0454b0d22f48"), new Guid("d0a95d9a-c2e8-41c1-ab08-188e3c15f169") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81882136-1a64-496d-b78b-420ee68fcf92"), new Guid("e6c8382d-ab23-4d39-8bdf-5026d8c4cf3d") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("81882136-1a64-496d-b78b-420ee68fcf92"), new Guid("eaeb06ad-6dbd-491e-9aa6-60e339c20bde") });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("0a17cce9-7172-4fc5-bdc1-0454b0d22f48"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("81882136-1a64-496d-b78b-420ee68fcf92"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f36ed4d1-8fc7-4cf2-8e4b-9db05c83e306"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8c4dd648-d3b4-4573-b7d1-add1c3064f13"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("be663005-f2c3-4ac7-9287-921c027d9388"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("d0a95d9a-c2e8-41c1-ab08-188e3c15f169"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("e6c8382d-ab23-4d39-8bdf-5026d8c4cf3d"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("eaeb06ad-6dbd-491e-9aa6-60e339c20bde"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "ArticleImages");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "ArticleImages",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("adb10406-74a5-43d0-8dc4-7c7601a2be81"), new DateTime(2024, 9, 24, 18, 50, 18, 562, DateTimeKind.Local).AddTicks(8090) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("23cd5436-94e4-4428-bc70-d852d40e135d"), new DateTime(2024, 9, 24, 18, 50, 18, 562, DateTimeKind.Local).AddTicks(8146) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("ed33ce45-691f-4fb9-b363-bf030e3bbba1"), new DateTime(2024, 9, 24, 18, 50, 18, 562, DateTimeKind.Local).AddTicks(8149) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("e0d55b4b-b6b5-49ee-bbd7-95ae242c3391"), new DateTime(2024, 9, 24, 18, 50, 18, 562, DateTimeKind.Local).AddTicks(8151) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("a4523db6-ab98-41ed-a598-11419ad168e3"), new DateTime(2024, 9, 24, 18, 50, 18, 562, DateTimeKind.Local).AddTicks(8158) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("adb10406-74a5-43d0-8dc4-7c7601a2be81"), new DateTime(2024, 9, 24, 18, 50, 18, 562, DateTimeKind.Local).AddTicks(8160) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("23cd5436-94e4-4428-bc70-d852d40e135d"), new DateTime(2024, 9, 24, 18, 50, 18, 562, DateTimeKind.Local).AddTicks(8163) });

            migrationBuilder.UpdateData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "AppUserId", "CreatedAt" },
                values: new object[] { new Guid("ed33ce45-691f-4fb9-b363-bf030e3bbba1"), new DateTime(2024, 9, 24, 18, 50, 18, 562, DateTimeKind.Local).AddTicks(8168) });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("64ec8363-9d54-498a-b3da-3aba1925b8e4"), null, "Admin", "ADMIN" },
                    { new Guid("d54d970d-dff1-49b4-bd4f-438f0b3a8bec"), null, "Author", "AUTHOR" },
                    { new Guid("fc815bfa-4553-4fa5-a122-d87dd80d6fda"), null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreatedAt", "Email", "EmailConfirmed", "FirstName", "IsDeleted", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("23cd5436-94e4-4428-bc70-d852d40e135d"), 0, "c91520e7-0916-472f-8384-01b5c04f580b", new DateTime(2024, 9, 24, 18, 50, 18, 285, DateTimeKind.Local).AddTicks(9906), "user2@example.com", true, "Jane", false, "Doe", false, null, "USER2@EXAMPLE.COM", "USER2", "AQAAAAIAAYagAAAAEHS9mzWhVDWWAkscl4Vr1u1Cc1RRUsW1DP/e4kjrZb6PmO8VYEINzT49TxVE84ihMQ==", null, false, "", false, "user2" },
                    { new Guid("a4523db6-ab98-41ed-a598-11419ad168e3"), 0, "e13a370c-c72f-451a-88c9-a435ee8151e0", new DateTime(2024, 9, 24, 18, 50, 18, 497, DateTimeKind.Local).AddTicks(3725), "user5@example.com", true, "Marry", false, "Doe", false, null, "USER5@EXAMPLE.COM", "USER5", "AQAAAAIAAYagAAAAEAN5lODC/aVNAFsyh7TIFPEssccQPPmnG7WF3HswdDLLv7YiegIiM8w426N94DLiYQ==", null, false, "", false, "user5" },
                    { new Guid("adb10406-74a5-43d0-8dc4-7c7601a2be81"), 0, "aee8acaf-cf04-4698-bdb3-c6824e485c80", new DateTime(2024, 9, 24, 18, 50, 18, 221, DateTimeKind.Local).AddTicks(6897), "user1@example.com", true, "John", false, "Doe", false, null, "USER1@EXAMPLE.COM", "USER1", "AQAAAAIAAYagAAAAEGxoDpw62TiB4yw/NxUny7yrX8fHAL4NJO7pQlgUy+YuctzhyxpwcSBuSaUilIjfmQ==", null, false, "", false, "user1" },
                    { new Guid("e0d55b4b-b6b5-49ee-bbd7-95ae242c3391"), 0, "0db32de0-ef7b-477f-9603-38f65dfcb204", new DateTime(2024, 9, 24, 18, 50, 18, 426, DateTimeKind.Local).AddTicks(1051), "user4@example.com", true, "Hans", false, "Doe", false, null, "USER4@EXAMPLE.COM", "USER4", "AQAAAAIAAYagAAAAEE3zypLDRZOj+5YmX/xJTofktsWhRxzAxaoj4915Lrc5K3sIh0tlqXrv7AuocNgx9w==", null, false, "", false, "user4" },
                    { new Guid("ed33ce45-691f-4fb9-b363-bf030e3bbba1"), 0, "755feb5c-35df-4c05-ada6-45dea4ff13ae", new DateTime(2024, 9, 24, 18, 50, 18, 352, DateTimeKind.Local).AddTicks(7072), "user3@example.com", true, "Mark", false, "Doe", false, null, "USER3@EXAMPLE.COM", "USER3", "AQAAAAIAAYagAAAAEJXaQg6vqEn9768aLz1bkmhpSrdRVUw0/Tw8NVfuMu31rCS+KkK5FXov9Bgpkh722w==", null, false, "", false, "user3" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("d54d970d-dff1-49b4-bd4f-438f0b3a8bec"), new Guid("23cd5436-94e4-4428-bc70-d852d40e135d") },
                    { new Guid("fc815bfa-4553-4fa5-a122-d87dd80d6fda"), new Guid("a4523db6-ab98-41ed-a598-11419ad168e3") },
                    { new Guid("64ec8363-9d54-498a-b3da-3aba1925b8e4"), new Guid("adb10406-74a5-43d0-8dc4-7c7601a2be81") },
                    { new Guid("fc815bfa-4553-4fa5-a122-d87dd80d6fda"), new Guid("e0d55b4b-b6b5-49ee-bbd7-95ae242c3391") },
                    { new Guid("fc815bfa-4553-4fa5-a122-d87dd80d6fda"), new Guid("ed33ce45-691f-4fb9-b363-bf030e3bbba1") }
                });
        }
    }
}
