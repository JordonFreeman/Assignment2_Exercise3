using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class FixAgentIDRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Item_ItemID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Item_ItemID1",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Agents_AgentID",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Agents_AgentID1",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agents",
                table: "Agents");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "CustomerName",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Agents");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "Agents",
                newName: "Agent");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AgentID1",
                table: "Order",
                newName: "IX_Order_AgentID1");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_AgentID",
                table: "Order",
                newName: "IX_Order_AgentID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_OrderID",
                table: "OrderDetail",
                newName: "IX_OrderDetail_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ItemID1",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ItemID1");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetails_ItemID",
                table: "OrderDetail",
                newName: "IX_OrderDetail_ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agent",
                table: "Agent",
                column: "AgentID");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Agent_AgentID",
                table: "Order",
                column: "AgentID",
                principalTable: "Agent",
                principalColumn: "AgentID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Agent_AgentID1",
                table: "Order",
                column: "AgentID1",
                principalTable: "Agent",
                principalColumn: "AgentID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Item_ItemID",
                table: "OrderDetail",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Item_ItemID1",
                table: "OrderDetail",
                column: "ItemID1",
                principalTable: "Item",
                principalColumn: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail",
                column: "OrderID",
                principalTable: "Order",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Agent_AgentID",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Agent_AgentID1",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Item_ItemID",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Item_ItemID1",
                table: "OrderDetail");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetail_Order_OrderID",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agent",
                table: "Agent");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Agent",
                newName: "Agents");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_OrderID",
                table: "OrderDetails",
                newName: "IX_OrderDetails_OrderID");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ItemID1",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ItemID1");

            migrationBuilder.RenameIndex(
                name: "IX_OrderDetail_ItemID",
                table: "OrderDetails",
                newName: "IX_OrderDetails_ItemID");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AgentID1",
                table: "Orders",
                newName: "IX_Orders_AgentID1");

            migrationBuilder.RenameIndex(
                name: "IX_Order_AgentID",
                table: "Orders",
                newName: "IX_Orders_AgentID");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Item",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Item",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Item",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "CustomerName",
                table: "Orders",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Agents",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "AgentID");

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "AgentID",
                keyValue: -2,
                column: "Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Agents",
                keyColumn: "AgentID",
                keyValue: -1,
                column: "Id",
                value: null);

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: -3,
                columns: new[] { "CreatedDate", "Id", "Name", "Price" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0m });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: -2,
                columns: new[] { "CreatedDate", "Id", "Name", "Price" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0m });

            migrationBuilder.UpdateData(
                table: "Item",
                keyColumn: "ItemID",
                keyValue: -1,
                columns: new[] { "CreatedDate", "Id", "Name", "Price" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, 0m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: -2,
                columns: new[] { "CustomerName", "Total" },
                values: new object[] { "Jane Smith", 275.50m });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "OrderID",
                keyValue: -1,
                columns: new[] { "CustomerName", "Total" },
                values: new object[] { "John Doe", 150.00m });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Item_ItemID",
                table: "OrderDetails",
                column: "ItemID",
                principalTable: "Item",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Item_ItemID1",
                table: "OrderDetails",
                column: "ItemID1",
                principalTable: "Item",
                principalColumn: "ItemID");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Orders_OrderID",
                table: "OrderDetails",
                column: "OrderID",
                principalTable: "Orders",
                principalColumn: "OrderID",
                onDelete: ReferentialAction.Cascade);

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
    }
}
