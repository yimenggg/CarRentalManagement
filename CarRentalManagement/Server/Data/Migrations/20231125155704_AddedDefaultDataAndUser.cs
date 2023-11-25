using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CarRentalManagement.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedDefaultDataAndUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookigns_Customers_CustomerId",
                table: "Bookigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookigns_Vehicles_VehicleId",
                table: "Bookigns");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Colours_ColourId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Models",
                table: "Models");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colours",
                table: "Colours");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookigns",
                table: "Bookigns");

            migrationBuilder.RenameTable(
                name: "Models",
                newName: "Model");

            migrationBuilder.RenameTable(
                name: "Colours",
                newName: "Colour");

            migrationBuilder.RenameTable(
                name: "Bookigns",
                newName: "Bookings");

            migrationBuilder.RenameIndex(
                name: "IX_Bookigns_VehicleId",
                table: "Bookings",
                newName: "IX_Bookings_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookigns_CustomerId",
                table: "Bookings",
                newName: "IX_Bookings_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Model",
                table: "Model",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colour",
                table: "Colour",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ad2bcf0c-20db-474f-8407-5a6b159518ba", null, "Administrator", "ADMINISTRATOR" },
                    { "bd2bcf0c-20db-474f-8407-5a6b159518bb", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "3781efa7-66dc-47f0-860f-e506d04102e4", 0, "a389e3f3-a3e4-4f61-a53e-a0e591469fd0", "admin@localhost.com", false, "Admin", "User", false, null, "ADMIN@LOCALHOST.COM", "ADMIN@LOCALHOST.COM", "AQAAAAIAAYagAAAAECNxo0JodHpKMr+4pmZHx7f0zkTx0S8SzKDzj86jOEcPmHQE1tf9XLZmz81NFZ6/HA==", null, false, "a406716e-329c-4ad7-a0c8-6a723b977f9c", false, "admin@localhost.com" });

            migrationBuilder.InsertData(
                table: "Colour",
                columns: new[] { "id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7342), new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7352), "Black", "System" },
                    { 2, "System", new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7353), new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7354), "Blue", "System" }
                });

            migrationBuilder.InsertData(
                table: "Makes",
                columns: new[] { "id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7693), new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7694), "BMW", "System" },
                    { 2, "System", new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7695), new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7696), "Toyata", "System" }
                });

            migrationBuilder.InsertData(
                table: "Model",
                columns: new[] { "id", "CreatedBy", "DateCreated", "DateUpdated", "Name", "UpdatedBy" },
                values: new object[,]
                {
                    { 1, "System", new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7848), new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7849), "3 Series", "System" },
                    { 2, "System", new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7850), new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7851), "X5", "System" },
                    { 3, "System", new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7852), new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7853), "Prius", "System" },
                    { 4, "System", new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7854), new DateTime(2023, 11, 25, 23, 57, 3, 876, DateTimeKind.Local).AddTicks(7854), "Rav4", "System" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Vehicles_VehicleId",
                table: "Bookings",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Colour_ColourId",
                table: "Vehicles",
                column: "ColourId",
                principalTable: "Colour",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Model_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "Model",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Customers_CustomerId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Vehicles_VehicleId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Colour_ColourId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Model_ModelId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Model",
                table: "Model");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colour",
                table: "Colour");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bd2bcf0c-20db-474f-8407-5a6b159518bb");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "ad2bcf0c-20db-474f-8407-5a6b159518ba", "3781efa7-66dc-47f0-860f-e506d04102e4" });

            migrationBuilder.DeleteData(
                table: "Colour",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Colour",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Makes",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Model",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ad2bcf0c-20db-474f-8407-5a6b159518ba");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3781efa7-66dc-47f0-860f-e506d04102e4");

            migrationBuilder.RenameTable(
                name: "Model",
                newName: "Models");

            migrationBuilder.RenameTable(
                name: "Colour",
                newName: "Colours");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Bookigns");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_VehicleId",
                table: "Bookigns",
                newName: "IX_Bookigns_VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_CustomerId",
                table: "Bookigns",
                newName: "IX_Bookigns_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Models",
                table: "Models",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colours",
                table: "Colours",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookigns",
                table: "Bookigns",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookigns_Customers_CustomerId",
                table: "Bookigns",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookigns_Vehicles_VehicleId",
                table: "Bookigns",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Colours_ColourId",
                table: "Vehicles",
                column: "ColourId",
                principalTable: "Colours",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Models_ModelId",
                table: "Vehicles",
                column: "ModelId",
                principalTable: "Models",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
