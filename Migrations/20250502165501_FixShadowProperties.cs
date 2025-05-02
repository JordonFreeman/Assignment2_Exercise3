using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class FixShadowProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "PK_Item",
                table: "Item");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agent",
                table: "Agent");

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: -3);

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "OrderDetail",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: -1);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "OrderDetail",
                newName: "OrderDetails");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.RenameTable(
                name: "Agent",
                newName: "Agents");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "OrderDetails",
                newName: "Id");

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

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "OrderDetails",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetails",
                table: "OrderDetails",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agents",
                table: "Agents",
                column: "AgentID");

            migrationBuilder.InsertData(
                table: "OrderDetails",
                columns: new[] { "Id", "ItemID", "ItemID1", "OrderID", "Quantity", "TotalAmount", "UnitAmount" },
                values: new object[,]
                {
                    { -3, -2, null, -2, 1, 275.50m, 275.50m },
                    { -2, -3, null, -1, 1, 50.00m, 50.00m },
                    { -1, -1, null, -1, 2, 100.00m, 50.00m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Items_ItemID",
                table: "OrderDetails",
                column: "ItemID",
                principalTable: "Items",
                principalColumn: "ItemID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderDetails_Items_ItemID1",
                table: "OrderDetails",
                column: "ItemID1",
                principalTable: "Items",
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
                onDelete: ReferentialAction.Restrict);

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
                name: "FK_OrderDetails_Items_ItemID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_ItemID1",
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
                name: "PK_Items",
                table: "Items");

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

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "OrderDetails",
                newName: "OrderDetail");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

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

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "OrderDetail",
                newName: "ID");

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

            migrationBuilder.AlterColumn<int>(
                name: "ID",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "OrderDetail",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "OrderID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderDetail",
                table: "OrderDetail",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ItemID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agent",
                table: "Agent",
                column: "AgentID");

            migrationBuilder.InsertData(
                table: "OrderDetail",
                columns: new[] { "Id", "ID", "ItemID", "ItemID1", "OrderID", "Quantity", "TotalAmount", "UnitAmount" },
                values: new object[,]
                {
                    { -3, 0, -2, null, -2, 1, 275.50m, 275.50m },
                    { -2, 0, -3, null, -1, 1, 50.00m, 50.00m },
                    { -1, 0, -1, null, -1, 2, 100.00m, 50.00m }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Agent_AgentID",
                table: "Order",
                column: "AgentID",
                principalTable: "Agent",
                principalColumn: "AgentID",
                onDelete: ReferentialAction.Restrict);

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
    }
}
