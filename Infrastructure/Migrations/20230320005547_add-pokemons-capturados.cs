using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class addpokemonscapturados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "USR_DT_NASCIMENTO",
                table: "AspNetUsers",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "USR_IDADE",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TB_PokemonsCapturados",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    PKM_ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    PKM_ATIVO = table.Column<bool>(type: "INTEGER", nullable: false),
                    PKM_DATA_CAPTURADO = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PKM_DATA_ALTERACAO = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PokemonsCapturados", x => x.PKM_ID);
                    table.ForeignKey(
                        name: "FK_TB_PokemonsCapturados_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_PokemonsCapturados_UserId",
                table: "TB_PokemonsCapturados",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PokemonsCapturados");

            migrationBuilder.DropColumn(
                name: "USR_DT_NASCIMENTO",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "USR_IDADE",
                table: "AspNetUsers");
        }
    }
}
