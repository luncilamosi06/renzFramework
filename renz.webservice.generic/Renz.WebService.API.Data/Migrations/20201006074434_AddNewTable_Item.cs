using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RivTech.WebService.Generic.Data.Migrations
{
    public partial class AddNewTable_Item : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LvItem",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Weight = table.Column<long>(nullable: false),
                    TotalCost = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LvItem", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LvItem_Name",
                table: "LvItem",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LvItem");
        }
    }
}
