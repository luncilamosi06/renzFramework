using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RivTech.WebService.Generic.Data.Migrations
{
    public partial class AddTable_Weight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LvWeight",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsActive = table.Column<bool>(nullable: false),
                    Priority = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Rule = table.Column<long>(nullable: false),
                    Operator = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Cost = table.Column<long>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LvWeight", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LvWeight_Priority",
                table: "LvWeight",
                column: "Priority",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LvWeight");
        }
    }
}
