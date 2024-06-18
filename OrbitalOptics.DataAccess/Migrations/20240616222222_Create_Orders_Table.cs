using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrbitalOptics.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class Create_Orders_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartPrice_Carts_CartId",
                table: "CartPrice");

            migrationBuilder.DropForeignKey(
                name: "FK_CartPrice_Prices_PriceId",
                table: "CartPrice");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CartPrice",
                table: "CartPrice");

            migrationBuilder.RenameTable(
                name: "CartPrice",
                newName: "Carts_Prices");

            migrationBuilder.RenameIndex(
                name: "IX_CartPrice_PriceId",
                table: "Carts_Prices",
                newName: "IX_Carts_Prices_PriceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Carts_Prices",
                table: "Carts_Prices",
                columns: new[] { "CartId", "PriceId" });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TotalPrice",
                table: "Orders",
                column: "TotalPrice");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Prices_Carts_CartId",
                table: "Carts_Prices",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Prices_Prices_PriceId",
                table: "Carts_Prices",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Prices_Carts_CartId",
                table: "Carts_Prices");

            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Prices_Prices_PriceId",
                table: "Carts_Prices");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Carts_Prices",
                table: "Carts_Prices");

            migrationBuilder.RenameTable(
                name: "Carts_Prices",
                newName: "CartPrice");

            migrationBuilder.RenameIndex(
                name: "IX_Carts_Prices_PriceId",
                table: "CartPrice",
                newName: "IX_CartPrice_PriceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CartPrice",
                table: "CartPrice",
                columns: new[] { "CartId", "PriceId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CartPrice_Carts_CartId",
                table: "CartPrice",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CartPrice_Prices_PriceId",
                table: "CartPrice",
                column: "PriceId",
                principalTable: "Prices",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
