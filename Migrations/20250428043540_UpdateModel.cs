using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_ItemID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_ItemID1",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.RenameTable(
                name: "Items",
                newName: "Item");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Item",
                table: "Item",
                column: "ItemID");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Item_ItemID",
                table: "OrderDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Item_ItemID1",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Item",
                table: "Item");

            migrationBuilder.RenameTable(
                name: "Item",
                newName: "Items");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemID");

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
        }
    }
}
