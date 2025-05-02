using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class PendingModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: 3);

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

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Orders",
                newName: "AgentID");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AgentId",
                table: "Orders",
                newName: "IX_Orders_AgentID");

            migrationBuilder.AlterColumn<int>(
                name: "AgentID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AgentID1",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<int>(
                name: "AgentID",
                table: "Agents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Agents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "AgentID");

            migrationBuilder.InsertData(
                table: "Agents",
                columns: new[] { "AgentID", "Address", "AgentName", "ContactNumber", "Email", "Id" },
                values: new object[,]
                {
                    { -2, "456 Oak Ave", "Agent Jones", "555-5678", "agent.jones@example.com", null },
                    { -1, "123 Main St", "Agent Smith", "555-1234", "agent.smith@example.com", null }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemID", "CreatedDate", "Description", "Id", "ItemName", "Name", "Price", "Size", "StockQuantity", "UnitPrice" },
                values: new object[,]
                {
                    { -3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Headphones", null, 0m, "Over-ear", 200, 89.99m },
                    { -2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Smartphone", null, 0m, "6-inch", 100, 699.99m },
                    { -1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 0, "Laptop", null, 0m, "15-inch", 50, 999.99m }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "OrderID", "AgentID", "AgentID1", "CustomerName", "OrderDate", "Status", "Total", "TotalAmount" },
                values: new object[,]
                {
                    { -2, -2, null, "Jane Smith", new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Pending", 275.50m, 275.50m },
                    { -1, -1, null, "John Doe", new DateTime(2023, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Completed", 150.00m, 150.00m }
                });

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "ID", "ItemID", "ItemID1", "OrderID", "Quantity", "TotalAmount", "UnitAmount" },
                values: new object[,]
                {
                    { -3, 0, -2, null, -2, 1, 275.50m, 275.50m },
                    { -2, 0, -3, null, -1, 1, 50.00m, 50.00m },
                    { -1, 0, -1, null, -1, 2, 100.00m, 50.00m }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_AgentID1",
                table: "Orders",
                column: "AgentID1");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Agents_AgentID",
                table: "Orders",
                column: "AgentID",
                principalTable: "Agents",
                principalColumn: "AgentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Agents_AgentID1",
                table: "Orders",
                column: "AgentID1",
                principalTable: "Agents",
                principalColumn: "AgentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Agents_AgentID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Agents_AgentID1",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_AgentID1",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "OrderDetails",
                keyColumn: "Id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "AgentID",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "Agents",
                keyColumn: "AgentID",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "AgentID1",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Items");

            migrationBuilder.RenameColumn(
                name: "AgentID",
                table: "Orders",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AgentID",
                table: "Orders",
                newName: "IX_Orders_AgentId");

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
                name: "Id",
                table: "Agents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "AgentID",
                table: "Agents",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "Id");

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
    }
}
