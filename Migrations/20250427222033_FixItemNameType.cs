using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OrderManagement.RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class FixItemNameType : Migration
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

            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ItemID1",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ItemID1",
                table: "OrderDetails");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Items",
                type: "nvarchar(max)",
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
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Items",
                type: "nvarchar(50)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Items",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderDetails_Items_ItemID",
                table: "OrderDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Items",
                table: "Items");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyColumnType: "int",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "ItemID1",
                table: "OrderDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ItemName",
                table: "Items",
                type: "nvarchar(max)",
                nullable: true,
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

            migrationBuilder.AddPrimaryKey(
                name: "PK_Items",
                table: "Items",
                column: "ItemID");

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
        }
    }
}
