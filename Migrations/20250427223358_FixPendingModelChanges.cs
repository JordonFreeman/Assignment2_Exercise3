using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class FixPendingModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_ItemID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Agents_AgentID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.RenameColumn(
                name: "AgentID",
                table: "Orders",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AgentID",
                table: "Orders",
                newName: "IX_Orders_AgentId");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AgentId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "AgentID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ItemID1",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Items",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Agents",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "Agents",
                type: "nvarchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AgentName",
                table: "Agents",
                type: "nvarchar(50)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Agents",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemID");

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "Id", "Address", "AgentID", "AgentName", "ContactNumber", "Email" },
                values: new object[,]
                {
                    { 1, "123 Main St", 0, "Agent Smith", "555-1234", "agent.smith@example.com" },
                    { 2, "456 Oak Ave", 0, "Agent Jones", "555-5678", "agent.jones@example.com" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "Description", "Id", "ItemName", "Name", "Price", "Size", "StockQuantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, null, 0, "Item 1", null, 0m, "Large", 50, 10.99m },
                    { 2, null, 0, "Item 2", null, 0m, "Medium", 30, 9.99m },
                    { 3, null, 0, "Item 3", null, 0m, "Small", 20, 12.99m }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "Email", "IsLocked", "LastLogin", "Password", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, null, false, null, "password", null, "admin" },
                    { 2, null, false, null, "user123", null, "user" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "AgentID", "AgentId", "CustomerName", "OrderDate", "Status", "Total", "TotalAmount" },
                values: new object[,]
                {
                    { 1, 1, null, "John Doe", new DateTime(2025, 4, 23, 5, 33, 58, 19, DateTimeKind.Local).AddTicks(6462), "Completed", 150.00m, 150.00m },
                    { 2, 2, null, "Jane Smith", new DateTime(2025, 4, 26, 5, 33, 58, 20, DateTimeKind.Local).AddTicks(8203), "Pending", 275.50m, 275.50m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "ID", "ItemID", "ItemID1", "OrderID", "Quantity", "TotalAmount", "UnitAmount" },
                values: new object[,]
                {
                    { 1, 0, 1, null, 1, 2, 100.00m, 50.00m },
                    { 2, 0, 2, null, 1, 1, 50.00m, 50.00m },
                    { 3, 0, 3, null, 2, 3, 275.50m, 91.83m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AgentID",
                table: "Orders",
                column: "AgentID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ItemID1",
                table: "OrderDetails",
                column: "ItemID1");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Items_ItemID",
                table: "OrderDetails",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Items_ItemID1",
                table: "OrderDetails",
                column: "ItemID1",
                principalTable: "Items",
                principalColumn: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Agents_AgentID",
                table: "Orders",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Agents_AgentId",
                table: "Orders",
                column: "AgentId",
                principalTable: "Agents",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_ItemID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_ItemID1",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Agents_AgentID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Agents_AgentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AgentID",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ItemID1",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AgentID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderDetails");

            migrationBuilder.DropColumn(
                name: "ItemID1",
                table: "OrderDetails");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Orders",
                newName: "AgentID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AgentId",
                table: "Orders",
                newName: "IX_Orders_AgentID");

            migrationBuilder.AlterColumn<string>(
                name: "UserName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<int>(
                name: "AgentID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Items",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ItemID",
                table: "Items",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "ContactNumber",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AlterColumn<string>(
                name: "AgentName",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "Agents",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Description", "ItemID", "ItemName", "Name", "Price", "Size", "StockQuantity", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Description 1", 0, "Item 1 Name", "Item 1", 10.99m, "Large", 0, 0m },
                    { 2, "Description 2", 0, "Item 2 Name", "Item 2", 9.99m, "Medium", 0, 0m },
                    { 3, "Description 3", 0, "Item 3 Name", "Item 3", 12.99m, "Small", 0, 0m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Items_ItemID",
                table: "OrderDetails",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Agents_AgentID",
                table: "Orders",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
