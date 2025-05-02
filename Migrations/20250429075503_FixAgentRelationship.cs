using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderManagement.RazorWeb.Migrations
{
    /// <inheritdoc />
    public partial class FixAgentRelationship : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Agent_AgentID",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(20)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Agent_AgentID",
                table: "Order",
                column: "AgentID",
                principalTable: "Agent",
                principalColumn: "AgentID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Agent_AgentID",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "Order",
                type: "nvarchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Agent_AgentID",
                table: "Order",
                column: "AgentID",
                principalTable: "Agent",
                principalColumn: "AgentID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
